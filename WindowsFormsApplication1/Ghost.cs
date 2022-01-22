using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
   
    public abstract class Ghost: Being
    {
        int TimeBeforeScattering = 1200;   //Вредмя до включения режима Разбегания
        int TimeBeforeChasing = 480;       // Время для включения режима Преследования
        int TickScattering = 0;            // Хранит время для перехода от одного режима до другого
        int AmountScattering = 0;          // Сколько раз Призраки переходили в режим Разбегания
        protected Point NextLocation;      // Координаты следующего местоположения призрака  
        protected Point PacmanLocation;    //Текущие координаты пакмана
        Point PastLocation;                // Координаты прошлого местоположения призрака     
        bool FlagScattering = false;       // Если true, то включен режим Разбегания
        bool FlagStart = false;            // Если true, то Призрак уже был на начальной позиции(Вышел из домика Призраков)
             
        public PictureBox ImgGhost = new PictureBox(); // PictureBox для изображения Призрака
        
        Wall[] _Wall;                      // Массив стен
       
        public Ghost(Point location ) : base()
        {
            ImgGhost.Location = location;
            ImgGhost.Size = new System.Drawing.Size(SizeBeing, SizeBeing);
            ImgGhost.SizeMode = PictureBoxSizeMode.StretchImage;
            ImgGhost.Move += new System.EventHandler(this.MoveGhost);
            ImgGhost.BackColor = Color.Black;
            NextLocation = new Point (location.X - 1, location.Y);

            //Привязка функции к событию на тик таймер 
            this.AnimTimer.Tick += new System.EventHandler(this.Tick);
            AnimTimer.Interval = TickTack;
        }//end Ghost(Point location)

   

        //Функция 
        private void Tick(object AnimTimer, EventArgs e)
        {
            //Если Призрак находится перед Домиком
            if (StartLocation == ImgGhost.Location)
                FlagStart = true;
            TickScattering++;

            //Условие прохождение TimeBeforeScattering времени для включения режима Разбегания
            if (TickScattering == TimeBeforeScattering)
            {
                //Если режимов Разбегания было меньше 2
                if (AmountScattering < 2)
                {
                    AmountScattering++;
                    FlagScattering = true;
                }//end if
                else
                    TimeBeforeScattering = 2 * TimeBeforeScattering; // Увеличиваем количество времени режима Преследования
            }//end if
            //После семи секунд режима Разбегания возвращение в режим Преследования
            if (TickScattering == TimeBeforeScattering + TimeBeforeChasing)
            {
                FlagScattering = false;
                TickScattering = 0;
            }//end if
            
            //MessageBox.Show((NextLocation.Y).ToString());

            //Запоминаем координаты предыдущего положения Призрака и присваиваем следующее
            PastLocation = ImgGhost.Location;
            ImgGhost.Location = NextLocation;

            Turning();  //Поворот изображения Призрака соответсвенно измениню вектора его движения
        }//end Tick()

        //Функция на изменение координат Призрака
        private void MoveGhost(object sender, EventArgs e)
        {
            int count = 0;                                   // Количество точек куда может шагнуть Призрак
            Point[] PossibleNewLoc = new Point[count];       // Массив точек куда может шагнуть Призрак
            int k;                                           // Индекс стены, в которую может врезатьсся Призрак
            int X = ImgGhost.Location.X;                     // Нынешняя позиция Призрака
            int Y = ImgGhost.Location.Y;                     // Нынешняя позиция Призрака
            Wall Door = _Wall[_Wall.Length - 1];             // Дверь Домика Призраков
            
            //Если Призрак не вышел из домика
            if (!FlagStart)
                if (ExitConditions())//Если условия выхода из домика произошли
                    Array.Resize(ref _Wall, _Wall.Length - 1);//Убираем Дверь Домика Призраков из массива стен
                else
                {
                    NextLocation = PastLocation;
                    return;
                }

            //Проверка на движение Призрака вправо
            CheckItem(X + Step, Y, _Wall, out k);
            MemorizeDirection(ref PossibleNewLoc, k, X + Step, Y,ref count);
            //Проверка на движение Призрака влево
            CheckItem(X - Step, Y, _Wall, out k);
            MemorizeDirection(ref PossibleNewLoc, k, X - Step, Y,ref count);
            //Проверка на двжиение Призрака вверх
            CheckItem(X, Y - Step, _Wall, out k);
            MemorizeDirection(ref PossibleNewLoc, k, X, Y - Step,ref count);
            //Проверка на двжиение Призрака вниз
            CheckItem(X, Y + Step, _Wall, out k);
            MemorizeDirection(ref PossibleNewLoc, k, X, Y + Step,ref count);

            //Если Призрак не вышел из домика
            if (!FlagStart)
            
                if (ExitConditions())//Если условия выхода из домика произошли
                {
                    //Выходим из Домика
                    NextLocation = BaseStepForDestination(PossibleNewLoc, StartLocation);
                    //Добавляем Дверь Домика Призраков в массив стен
                    Array.Resize(ref _Wall, _Wall.Length + 1);
                    _Wall[_Wall.Length - 1] = Door;                    
                    return;
                }//end if            


            //Если режим Разбегания
            if (FlagScattering)
                //Только начался
                if (TickScattering == TimeBeforeScattering)
                {
                    //то разворачиваемся на 180
                    NextLocation = PastLocation;                         
                }//end if
               else  
                    //иначе следуем режиму Разбегания
                    NextLocation = Scatter(PossibleNewLoc);
                    
            else   // Если Режим Преследования, то следуем режиму преследования
           NextLocation = StepForDestination(PossibleNewLoc, PacmanLocation);
        }//end MoveGhost()

        //Функция контролирующая точки куда может пойти Призрак
        private void MemorizeDirection(ref Point[] Location, int k, int X, int Y ,ref  int count  )
        {
            //Если рассматриваем точка не прошлая позиция Призрака
           if(PastLocation != new Point(X,Y))
               //Если нет стен в рассматриваемой позиции
            if (k < 0)
            {
                //Увеличивваем размер массива возможных направлений
                count++;                                 
                Array.Resize(ref Location, count);
                //Добавляем новую точку движения 
                Location[count - 1] = new Point(X , Y);

            }//end if
            return;
        }//end MemorizedDirection()

        //Функция для получения массива стен
     public void GetWall( Wall[] _wall)
     {
     _Wall = _wall;
     }//end GetWall

        //Функция для получения координат Пакмана
     public void GetPacman(Point location)
     {
         PacmanLocation = location;
     
     }//end GetPacman

        //Функция, которая выбирает куда будет ходить Призрак из предложенных точек
     virtual protected Point StepForDestination(Point[] Location, Point Destination)
     {

         int index = 0;
         double delta = 999;//большая положительная дельта для первого значения
         double _delta;
         //Цикл вычисляет при каком шаге расстояние до Пакмана по прямой будет минимальным 
         for (int i = 0; i < Location.Length; i++)
         {
             _delta = Math.Sqrt(Math.Pow((Destination.X - Location[i].X), 2) + Math.Pow((Destination.Y - Location[i].Y), 2));
             if (_delta < delta)
             {
                 delta = _delta;
                 index = i;
             }//end if

         }//end for i
         //Возвращаем шаг при котором расстояние между привиением и Пакманаом минимально
         return Location[index];

     }//end StepForDestination()

        //Функция описывающая алгоритм режима Разбегания Призрака
     abstract protected Point Scatter(Point[] Location);

        //Функция поворачивающая Призрака в соответствии с вектором его движения
     abstract protected void Turning();

        //Функция задающая условия выхода из Домика Призраков
     abstract protected bool ExitConditions();

     //Функция вызывающая реализация предка функции StepForDestination
     abstract protected Point BaseStepForDestination(Point[] Location, Point Destination);
    }
}
