using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Threading;

namespace WindowsFormsApplication1
{

    public partial class FormLevelOne : Form, ILevel
    {
   
        const int AmountWall = 55; // Количество стен на уровне
        const int AmountFood = 0;  
        int Seconds = 0;           //для таймера
        int Minutes = 0;           //для таймера
        protected int Score = 0;             // Количество очков игрока
        int count = 0;             // Счётчик для еды
        int i = 0;                 //Счётчик для таймера
        int deadI = 0;

    







            protected Wall[] _Wall = new Wall[AmountWall];                                   //Массив стен
            Food[] _Food = new Food[AmountFood];                                             //Массив еды
            BtnPause btnPause = new BtnPause(75, 25, new Point(452, 13));                    //Кнопка паузы
            
        
            protected PackMan NewPackMan = new PackMan(new Point(260, 325));                 //Экезмпляр класса Пакмана
           
            protected GhostRed Blinky = new GhostRed(new Point(260, 205));                          
            GhostPink Pinky = new GhostPink(new Point(230, 240), new Point(99, 99));


            public FormLevelOne()
            {
                InitializeComponent();
                this.KeyPreview = true;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            }



        private void FormLevelOne_Load(object sender, EventArgs e)
        {
            //Добавляем Призраков и Пакмана на форму
            Controls.Add(NewPackMan.ImgPacman);
            Controls.Add(Blinky.ImgGhost);
            Controls.Add(Pinky.ImgGhost);
            //Controls.Add(Inky.ImgGhost);
   
            //Передаем массив стен Призракам
            Blinky.GetWall(_Wall);
            Pinky.GetWall(_Wall);
  
            //Привязываем к функции а изменения координат Призрака
            Blinky.ImgGhost.Move += new System.EventHandler(this.MoveGhost);
            Pinky.ImgGhost.Move += new System.EventHandler(this.MoveGhost);
          
            //Инициализируем массив PictureBox Призраков
            //PackOfGhosts[0] = Blinky.ImgGhost;
            //PackOfGhosts[1] = Pinky.ImgGhost;
            //PackOfGhosts[2] = Inky.ImgGhost;
            //PackOfGhosts[3] = Clyde.ImgGhost;
            
            // Задаем функцию на движения Пакмана
            NewPackMan.ImgPacman.Move += new System.EventHandler(this.MovePacMan);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pacman_KeyDown); // Функция на ажатие клавиш
            
            //Прописываем и добавляем на форму стены и еду
            InitWalls();
            InitFood();
            this.Controls.AddRange(_Wall);
            this.Controls.AddRange(_Food);

            //Подключение кнопку на Паузу
            this.Controls.Add(btnPause);
            btnPause.Click += new System.EventHandler(this.btnPause_Click);
            //Задержка для музыки
            delayForIntro();
        }

        //Проигрывание музыки в начале игры, если включена музыка
        private void delayForIntro()
        {
            timer1.Enabled = true;
            if (Sound.soundEnabled == true) // Это чтобы не ждать при отключенном звуке
            
                Pause();        
        }
        
        //Функция на нажатие клавиши
        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {    
            //MessageBox.Show("Okay");
            this.NewPackMan.MoveAndRotate(e, _Wall);

            //Если игрок нажмет Enter, то пауза
            if (e.KeyCode == Keys.Enter)
                Pause();           
              
            e.Handled = true;
        }

        
        //Функция при изменении координат Пакмана
        private void MovePacMan(object sender, EventArgs e)
        {
            //Проверки на стену в возможных направлениях движения
            NewPackMan.CheckWall(_Wall);            


            int NumberFood;//Хранит индекс съеденной еды
            NewPackMan.CheckFood(_Food, out NumberFood);
            if (NumberFood > -1)
                //Перекрашивает съеденую еду в черный
                if (_Food[NumberFood].BackColor == Color.Yellow)
                {
                    _Food[NumberFood].BackColor = Color.Black;
                    //_Food[NumberFood].Visible = false;
                    Score += 10;
                    lblNumScore.Text = Score.ToString();                    
                }

            //Телепортирует Пакмана если она заходит в проходы справа или слева
            Teleport(NewPackMan.ImgPacman);

            //Передача параметров Пакмана Призракам для корректировки их маршрута
            InfoForGhost();


 

            //for (int i = 0; i < PackOfGhosts.Length; i++ )
            //    if (NewPackMan.Dead(PackOfGhosts[i]))
            //    {
            //        Pause();
            //        Sound.PlayDead();
            //        timer2.Interval = 150;
            //        timer2.Enabled = true;
            //    }
           
            //Условие на победу
            if (Score / 10 == _Food.Length - 1)
            {
                Pause();
                MessageBox.Show("Поздравляем!!!\n Вы Победили!!!");
                this.Close();
            }//end if

        }

        protected virtual void InfoForGhost()
        {
            Blinky.GetPacman(NewPackMan.ImgPacman.Location);

            Pinky.GetPacman(NewPackMan.ImgPacman.Location);
            Pinky.GetPacmanAngle(NewPackMan.Angle);    
        }






        //Функция инициализации стен лабиринта
        public void InitWalls()
        {
            
            _Wall[0] = new Wall(335, 5, new Point(100, 100)); //стенка
            _Wall[1] = new Wall(5, 95, new Point(435, 100)); //стенка
            _Wall[2] = new Wall(340, 5, new Point(100, 405)); //стенка
            _Wall[3] = new Wall(5, 95, new Point(100, 100)); //стенка

            _Wall[4] = new Wall(40, 20, new Point(125, 125));  //левый верхний квадрат
            _Wall[5] = new Wall(40, 10, new Point(125, 165));  //полоска под верхним левым квадратом
            _Wall[6] = new Wall(60, 20, new Point(185, 125));  //прямоугольник справа от верхнего левого квадрата

            _Wall[7] = new Wall(10, 40, new Point(265, 105)); //верхняя перемычка

            _Wall[8] = new Wall(60, 20, new Point(295, 125)); //прямоугольник справа от верхней перемычки  

            _Wall[9] = new Wall(40, 20, new Point(375, 125));  //правый верхний квадрат
            _Wall[11] = new Wall(5, 40, new Point(160, 255));  // ЛЕВЫЕ ВЕРТИКАЛЬНЫЕ ПОЛОСКИ
            _Wall[13] = new Wall(5, 40, new Point(160, 195));  //

             
            _Wall[12] = new Wall(65, 5, new Point(100, 195));  // ЛЕВЫЕ ГОРИЗОНТАЛЬНЫЕ ПОЛОСКИ
            _Wall[14] = new Wall(65, 5, new Point(100, 230));  //
            _Wall[10] = new Wall(65, 5, new Point(100, 255)); //
            _Wall[15] = new Wall(65, 5, new Point(100, 290));  //
            
            _Wall[16] = new Wall(5, 120, new Point(100, 290)); //левая нижняя стенка
            _Wall[45] = new Wall(5, 120, new Point(435, 290));  //правая нижняя стенка

            _Wall[17] = new Wall(40, 10, new Point(125, 315)); //ЛЕВЫЙ УГОЛОК
            _Wall[18] = new Wall(10, 40, new Point(155, 315)); //

            _Wall[29] = new Wall(40, 10, new Point(375, 315)); //ПРАВЫЙ УГОЛОК
            _Wall[30] = new Wall(10, 40, new Point(375, 315)); //

            _Wall[19] = new Wall(35, 10, new Point(100, 345)); //левая перемычка
            _Wall[48] = new Wall(35, 10, new Point(405, 345)); //правая перемычка

            _Wall[20] = new Wall(10, 70, new Point(185, 165)); //ЛЕВАЯ ВЕРХНЯЯ БУКВА Т
            _Wall[21] = new Wall(60, 10, new Point(185, 195)); //

            _Wall[22] = new Wall(110, 10, new Point(215, 165)); //СРЕДНЯЯ ВЕРХНЯЯ БУКВА Т
            _Wall[23] = new Wall(10, 40, new Point(265, 165)); //

            _Wall[24] = new Wall(10, 70, new Point(345, 165)); //ПРАВАЯ ВЕРХНЯЯ БУКВА Т
            _Wall[25] = new Wall(60, 10, new Point(295, 195)); //

            _Wall[26] = new Wall(10, 40, new Point(185, 255)); // центральная левая вертикальная полоска
            _Wall[46] = new Wall(10, 40, new Point(345, 255)); // центральная правая вертикальная полоска

            _Wall[27] = new Wall(110, 10, new Point(215, 285)); //СРЕДНЯЯ СРЕДНЯЯ БУКВА Т
            _Wall[28] = new Wall(10, 40, new Point(265, 285)); // 

            _Wall[31] = new Wall(120, 10, new Point(295, 375)); //НИЖНЯЯ ЛЕВАЯ БУКВА Т
            _Wall[32] = new Wall(10, 40, new Point(345, 345)); //

            _Wall[33] = new Wall(60, 10, new Point(185, 315)); //нижняя левая горизонтальная полоска
            _Wall[47] = new Wall(60, 10, new Point(295, 315)); //нижняя правая горизонтальная полоска

            _Wall[34] = new Wall(120, 10, new Point(125, 375)); //НИЖНЯЯ ЛЕВАЯ БУКВА Т
            _Wall[35] = new Wall(10, 40, new Point(185, 345)); //

            _Wall[36] = new Wall(110, 10, new Point(215, 345)); //СРЕДНЯЯ НИЖНЯЯ БУКВА Т
            _Wall[37] = new Wall(10, 40, new Point(265, 345)); //

            _Wall[38] = new Wall(40, 10, new Point(375, 165)); // полоска под верхним правым квадратом

            _Wall[39] = new Wall(5, 40, new Point(375, 195));  // ПРАВЫЕ ВЕРТИКАЛЬНЫЕ ПОЛОСКИ
            _Wall[40] = new Wall(5, 40, new Point(375, 255));  //


            _Wall[41] = new Wall(65, 5, new Point(375, 195));  // ПРАВЫЕ ГОРИЗОНТАЛЬНЫЕ ПОЛОСКИ
            _Wall[42] = new Wall(65, 5, new Point(375, 230));  //
            _Wall[43] = new Wall(65, 5, new Point(375, 255)); //
            _Wall[44] = new Wall(65, 5, new Point(375, 290));  //;

            
            _Wall[49] = new Wall(110, 5, new Point(215, 260)); // ЦЕНТРАЛЬНЫЙ ПОЛЫЙ ПРЯМОУГОЛЬНИК
            _Wall[50] = new Wall(5, 40, new Point(215, 225)); //
            _Wall[51] = new Wall(5, 40, new Point(320, 225)); //
            _Wall[52] = new Wall(45, 5, new Point(215, 225)); //
            _Wall[53] = new Wall(45, 5, new Point(280, 225));
            _Wall[54] = new Wall(45, 5, new Point(260, 225));//Дверь
            _Wall[54].BackColor = Color.White;
            
        }// end InitWalls()

        //Функция создающая еду 
        private void FoodCreate(int x, int y) //создаёт еду
        {
            Array.Resize(ref _Food, _Food.Length + 1);
            _Food[count] = new Food(new Point(x, y));
            count++;
        }
        //Функция инициализации еды
        public void InitFood()
        {

            int coord = 114;


            FoodCreate(424, 379);

            FoodCreate(114, 379);
            FoodCreate(114, 364);
            FoodCreate(144, 349);
            FoodCreate(144, 334);
            FoodCreate(115, 334);
            FoodCreate(129, 334);
            FoodCreate(254, 379);
            FoodCreate(254, 365);
            FoodCreate(115, 115);

            coord = 128;
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                    FoodCreate(coord, 364);
                else if (i == 3 || i == 2)
                    FoodCreate(coord + 2, 364);
                else
                    FoodCreate(coord + 1, 364);
                coord += 15;
            }
            FoodCreate(174, 364);
            coord = 115;

            FoodCreate(253, 115);




            FoodCreate(285, 115);
            FoodCreate(364, 115);

            FoodCreate(424, 115);
            coord = 284;
            for (int i = 0; i < 4; i++)
            {

                coord += 16;
                FoodCreate(coord, 115);
            }
            coord = 364;
            for (int i = 0; i < 3; i++)
            {

                coord += 15;
                FoodCreate(coord, 115);
            }

            FoodCreate(285, 305);
            FoodCreate(364, 305);

            FoodCreate(424, 305);
            coord = 284;

            FoodCreate(300, 305);
            FoodCreate(317, 305);
            FoodCreate(334, 305);
            FoodCreate(348, 305);
            coord = 364;
            for (int i = 0; i < 3; i++)
            {

                coord += 15;
                FoodCreate(coord, 305);
            }
            FoodCreate(115, 305);
            coord = 115;
            for (int i = 0; i < 8; i++)
            {

                coord += 15;
                if (i == 7 || i == 8)
                    FoodCreate(coord + 2, 305);
                else if (i == 6)
                    FoodCreate(coord + 1, 305);
                else
                    FoodCreate(coord, 305);
            }
            FoodCreate(253, 305);


            FoodCreate(364, 334);
            FoodCreate(424, 334);
            FoodCreate(424, 319);
            FoodCreate(115, 319);
            FoodCreate(394, 334);
            FoodCreate(409, 334);
            FoodCreate(253, 334);
            FoodCreate(285, 334);

            FoodCreate(285, 379);
            FoodCreate(285, 365);

            FoodCreate(114, 394);
            FoodCreate(285, 394);
            FoodCreate(254, 394);
            FoodCreate(269, 394);
            FoodCreate(424, 394);
            FoodCreate(253, 319);
            FoodCreate(285, 319);
            FoodCreate(394, 319);
            FoodCreate(424, 365);
            FoodCreate(394, 364);
            FoodCreate(409, 364);
            FoodCreate(394, 349);
            FoodCreate(364, 349);
            FoodCreate(364, 364);
            FoodCreate(379, 364);
            FoodCreate(204, 365);
            FoodCreate(219, 365);
            FoodCreate(237, 365);


            FoodCreate(300, 365);
            FoodCreate(316, 365);
            FoodCreate(334, 365);
            FoodCreate(334, 349);
            FoodCreate(204, 349);
            FoodCreate(334, 334);
            FoodCreate(204, 334);

            FoodCreate(364, 319);
            FoodCreate(349, 334);
            FoodCreate(189, 334);
            FoodCreate(174, 319);
            FoodCreate(174, 334);
            FoodCreate(174, 349);

            FoodCreate(364, 289);
            FoodCreate(174, 289);
            coord = 114;
            for (int i = 0; i < 9; i++)
            {

                coord += 14;
                FoodCreate(coord, 394);
            }
            coord = 285;
            for (int i = 0; i < 9; i++)
            {

                coord += 14;
                FoodCreate(coord, 394);
            }

            FoodCreate(364, 274);
            FoodCreate(174, 274);

            FoodCreate(364, 244);
            FoodCreate(174, 244);



            FoodCreate(219, 334);
            FoodCreate(235, 334);

            FoodCreate(300, 334);

            FoodCreate(364, 229);
            FoodCreate(364, 214);
            FoodCreate(364, 199);
            FoodCreate(364, 185);
            FoodCreate(378, 185);
            FoodCreate(254, 185);
            FoodCreate(284, 185);
            FoodCreate(316, 334);
            FoodCreate(364, 170);

            FoodCreate(174, 229);
            FoodCreate(174, 214);
            FoodCreate(174, 199);
            FoodCreate(174, 185);
            FoodCreate(174, 260);

            FoodCreate(364, 260);

            FoodCreate(300, 185);
            FoodCreate(316, 185);
            FoodCreate(334, 185);
            FoodCreate(334, 169);
            FoodCreate(334, 155);
            FoodCreate(236, 185);
            FoodCreate(220, 185);
            FoodCreate(205, 185);
            FoodCreate(205, 169);
            FoodCreate(205, 155);
            FoodCreate(253, 128);
            FoodCreate(253, 141);
            FoodCreate(253, 155);
            FoodCreate(220, 155);
            FoodCreate(236, 155);
            FoodCreate(269, 155);

            FoodCreate(285, 128);
            FoodCreate(285, 141);
            FoodCreate(285, 155);
            FoodCreate(300, 155);
            FoodCreate(316, 155);
            FoodCreate(349, 155);
            FoodCreate(364, 155);
            FoodCreate(364, 141);
            FoodCreate(364, 128);
            FoodCreate(190, 155);
            FoodCreate(174, 169);
            FoodCreate(174, 155);
            FoodCreate(174, 141);
            FoodCreate(174, 128);
            FoodCreate(174, 115);
            FoodCreate(424, 128);
            FoodCreate(424, 141);
            FoodCreate(424, 155);
            FoodCreate(424, 169);
            FoodCreate(424, 185);
            FoodCreate(392, 185);
            FoodCreate(409, 185);
            FoodCreate(392, 155);
            FoodCreate(409, 155);
            FoodCreate(378, 155);
            FoodCreate(220, 115);
            FoodCreate(236, 115);
            FoodCreate(205, 115);
            FoodCreate(189, 115);
            FoodCreate(158, 115);
            FoodCreate(143, 115);
            FoodCreate(129, 115);
            FoodCreate(158, 155);
            FoodCreate(143, 155);
            FoodCreate(129, 155);
            FoodCreate(158, 185);
            FoodCreate(143, 185);
            FoodCreate(129, 185);
            FoodCreate(115, 128);
            FoodCreate(115, 141);
            FoodCreate(115, 155);
            FoodCreate(115, 185);
            FoodCreate(115, 169);
        }// end InitFood()

        //Функция телепортации из проходов слева и справа
        private void Teleport( Control _control  )
        {
            if (_control.Location.Y == 235)

                if (_control.Location.X == 80)
                    _control.Location = new Point(439, 235);
                else
                    if (_control.Location.X == 440)
                        _control.Location = new Point(81, 235);
        
        
        
        }//end Teleport()


        //Вызов паузы при нажатии на кнопку Pause
        private void btnPause_Click(object sender, EventArgs e)
        {
            Pause();
        }//end btnPause_Click

        //Функция на движения Призраков
        protected void MoveGhost(object sender, EventArgs e)
        {           
            //Телепортация Призрака, если он в левом или правом проходе
            Teleport((Control)sender);

            //Функция возращает true, если Призрак пересекается с Пакманом на достаточное кол-во пикселей
            if (NewPackMan.Dead((PictureBox)sender))
            {
                Pause();
                Sound.PlayDead();
                timer2.Interval = 150;
                timer2.Enabled = true;
                timer2.Start();
            }//end if
        }//end MoveGhost()

        //Таймер для анимации смерти Пакмана
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            deadI++;
            //MessageBox.Show(deadI.ToString());
            NewPackMan.DeadAnim(deadI - 1);
            InvisibleGhost(); 
            if (deadI == 10)
            {
                MessageBox.Show("Поражение\n" + "Ваш счёт: " + Score);
                this.Close();
                timer2.Enabled = false;
            }//end if

        }//end timer2_Tick

        protected virtual void InvisibleGhost()
        {
            Blinky.ImgGhost.Visible = false;
            Pinky.ImgGhost.Visible = false;
                     
               
        }



        //Функция Паузы
        protected virtual void Pause()
        {
            NewPackMan.Pause();
            Blinky.Pause();
            Pinky.Pause();
            
           
        }//end Pause()
        //Таймер для вывода времени для игрока и для вступления
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            // Обработка паузы для вступительной музыки

            if (Sound.soundEnabled == true && Score == 0)
        {
                if (i == 270)
                {
                    Pause();
                    i = 0;
                }//end if
                else return;
        }//end if

            //
            if (i % 60 == 0)
            {
                Seconds++;
                if (Seconds == 60)
                {
                    Seconds = 0;
                    Minutes++;
                }//end if
                if (Seconds < 10 && Minutes < 10)
                    lblTimer.Text = "0" + Minutes.ToString() + " : 0" + Seconds.ToString();
                else
                    if (Seconds < 10)
                        lblTimer.Text = Minutes.ToString() + " : 0" + Seconds.ToString();
                    else
                        if (Minutes < 10)
                            lblTimer.Text = "0" + Minutes.ToString() + " : " + Seconds.ToString();
                        else
                            lblTimer.Text = Minutes.ToString() + " : " + Seconds.ToString();
            }//end if
        }//end timer1_Tick

  
    }
}
