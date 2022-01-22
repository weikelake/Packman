using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class GhostPink : Ghost
    {
        const int PointAhead = 60;      // Расстояние до целевой точки от Пакмана
        Point DestinationForScatter;    //Целевая точка для режима Разбегания
        int PacmanAngle;                //Угол куда смотрит Пакман
        public GhostPink(Point location, Point _DestinationForScatter) : base(location)
        {
            ImgGhost.Image = Properties.Resources.pinky1;
            DestinationForScatter = _DestinationForScatter; // Целевая точка для Режима Разбегания
        }

        //Разбегания осуществляется по тому же алгоритма, что Преследование Пакмана
        //меняется лишь целевая точка
        override protected Point Scatter(Point[] Location)
        {
            return base.StepForDestination(Location, DestinationForScatter);
        }


        //Функция выбора следующего шага привидения
        override protected Point StepForDestination(Point[] Location, Point Destination)
        {
            //Выбираем точку впереди Пакмана в зависимости от того куда он движется
            switch (PacmanAngle)
            {
                case 0:
                    Destination.X += PointAhead;
                    break;
                case 90:
                    Destination.Y += PointAhead;
                    break;
                case 180:
                    Destination.X -= PointAhead;
                    break;
                case 270:
                    Destination.Y -= PointAhead;
                    break;
            }

            return base.StepForDestination(Location, Destination);
     }//end StepForDestination()

        //Функция для получения стороны, куда идёт Пакман
        public void GetPacmanAngle(int Angle)
        {
            PacmanAngle = Angle;       
        }//end GetPacmanAngle


        //Изменяет изображение приведения, чтобы оно смотрело в ту сторону куда идёт
        override protected void Turning()
        {
            if (ImgGhost.Location.X == NextLocation.X)
                if (ImgGhost.Location.Y - NextLocation.Y < 0)
                    ImgGhost.Image = Properties.Resources.pinky3;//Смотрит вниз
                else
                    ImgGhost.Image = Properties.Resources.pinky4;//Смотрит вверх
            else
                if (ImgGhost.Location.X - NextLocation.X < 0)
                    ImgGhost.Image = Properties.Resources.pinky2; // Смотрит вправо
                else
                    ImgGhost.Image = Properties.Resources.pinky1; // Смотрит влево     
        }// end Turning()

        //Изначально находится в Домике, но сразу выходит
        protected override bool ExitConditions()
        {
            return true;
        }

        //Использует базовую реализацию функции StepForDestination
        protected override Point BaseStepForDestination(Point[] Location, Point Destination)
        {
            return base.StepForDestination(Location, Destination);
        }
    }
}
