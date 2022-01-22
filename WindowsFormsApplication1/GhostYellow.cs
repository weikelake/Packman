using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class GhostYellow: Ghost
    {
        const int IntervalForChase = 80;//Расстояние между Призраком и Пакманом при увеличении которого ПРизрак начнёт преследовать Пакмана
        const int ScoreForExit = 500;   //Количество очков для выхода из Домика Призраков
        int Score;                      //Количество очков игрока
        Point DestinationForScatter;    //Целевая точка для режима Разбегания
        public GhostYellow(Point location, Point _DestinationForScatter) : base(location)
        {
            ImgGhost.Image = Properties.Resources.clyde1;
            DestinationForScatter = _DestinationForScatter;
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
            //Расчет расстояние до Пакмана
            double delta = Math.Sqrt(Math.Pow((ImgGhost.Location.X - PacmanLocation.X), 2)
                        + Math.Pow((ImgGhost.Location.Y - PacmanLocation.Y), 2));
            // Если расстояние до Пакмна больше заданного числа, то Призрак Рпеследует Пакмана
            if ( delta > IntervalForChase)               
                return base.StepForDestination(Location, Destination);
                
            
            else
                //Иначе Призрак идёт в точку Разбегания
                return Scatter(Location);
        }//end StepForDestination()

        //Изменяет изображение приведения, чтобы оно смотрело в ту сторону куда идёт
        override protected void Turning()
        {
            if (ImgGhost.Location.X == NextLocation.X)
                if (ImgGhost.Location.Y - NextLocation.Y < 0)
                    ImgGhost.Image = Properties.Resources.clyde3;//Смотрит вниз
                else
                    ImgGhost.Image = Properties.Resources.clyde4;//Смотрит вверх
            else
                if (ImgGhost.Location.X - NextLocation.X < 0)
                    ImgGhost.Image = Properties.Resources.clyde2; // Смотрит вправо
                else
                    ImgGhost.Image = Properties.Resources.clyde1; // Смотрит влево     
        }// end Turning()

        //Условия выхода из Домика Призраков при достижения игрком задданого кол-ва очков
        protected override bool ExitConditions()
        {
            if (Score >= ScoreForExit)
                return true;
            return false;
        }

        //Читает количество очков игрока
        public void GetScore(int _Score)
        {
            Score = _Score;
            
        }
        //Использует базовую реализацию функции StepForDestination
        protected override Point BaseStepForDestination(Point[] Location, Point Destination)
        {
            return base.StepForDestination(Location, Destination);
        }
    }
}
