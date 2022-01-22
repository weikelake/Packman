using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class GhostBlue:Ghost
    {
        const int PointAhead = 30;      //Расстояние до целевой точки от Пакмана
        const int ScoreForExit = 300;   //Количество очков для выхода из Домика Призраков
        Point DestinationForScatter;    //Целевая точка для режима Разбегания
        Point LocGhostRed;              //Координаты красного Призрака
        int PacmanAngle;                //Угол куда смотрит Пакман
        int Score;                      //Количество очков игрока
        public GhostBlue(Point location, Point _DestinationForScatter) : base(location)
        {
            ImgGhost.Image = Properties.Resources.inky1;
            DestinationForScatter = _DestinationForScatter; 
        }//end GhostBlue
        
        //Разбегания осуществляется по тому же алгоритма, что Преследование Пакмана
        //меняется лишь целевая точка
        override protected Point Scatter(Point[] Location)
        {
            return base.StepForDestination(Location, DestinationForScatter);
        }//end Scatter()

        //Функция выбора следующего шага привидения
        override protected Point StepForDestination(Point[] Location, Point Destination)
        {
            //Выбираем точку впереди Пакмана
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
            }//end switch

            // Целевая точка - конец удвоенного вектора, начало которого в координатах красного Призрака,
            // а конец в точке перед Пакманом
            if (LocGhostRed.X <= Destination.X)
                Destination.X += (Destination.X - LocGhostRed.X);
            else
                Destination.X -= (LocGhostRed.X - Destination.X);

            if (LocGhostRed.Y <= Destination.Y)
                Destination.Y += (Destination.Y - LocGhostRed.Y);
            else
                Destination.Y -= (LocGhostRed.Y - Destination.Y);

            return base.StepForDestination(Location, Destination);
        }//end StepForDestination()



        public void GetPacmanAngle(int Angle)
        {
            PacmanAngle = Angle;
        }//end GetPacmanAngle

        public void GetGhostRed(Point _LocGhostRed)
        {
            LocGhostRed = _LocGhostRed;       
        }//end GetGhostRed


        override protected void Turning()
        {
            if (ImgGhost.Location.X == NextLocation.X)
                if (ImgGhost.Location.Y - NextLocation.Y < 0)
                    ImgGhost.Image = Properties.Resources.inky3;//Смотрит вниз
                else
                    ImgGhost.Image = Properties.Resources.inky4;//Смотрит вверх
            else
                if (ImgGhost.Location.X - NextLocation.X < 0)
                    ImgGhost.Image = Properties.Resources.inky2; // Смотрит вправо
                else
                    ImgGhost.Image = Properties.Resources.inky1; // Смотрит влево     
        }// end Turning()

        //Условия выхода из Домика Призраков при достижения игрком задданого кол-ва очков
        protected override bool ExitConditions()
        {
            if (Score >= ScoreForExit)
                return true;
            return false;
        }//end ExitConditions()


        //Читает количество очков игрока
        public void GetScore(int _Score)
        {
            Score = _Score;
        }//end GetScore()
        //Использует базовую реализацию функции StepForDestination
        protected override Point BaseStepForDestination(Point[] Location, Point Destination)
        {
           return base.StepForDestination(Location, Destination);
        }//end BaseStepForDestination()

    }
}
