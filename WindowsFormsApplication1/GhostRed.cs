using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApplication1
{
    public class GhostRed: Ghost
    {
        public GhostRed(Point location ) : base(location)
        {
            ImgGhost.Image = Properties.Resources.blinky1;            
        }//end GhostRed

        //В режиме Разбегания Призрак такде гонится за Пакманом
        override protected Point Scatter(Point[] Location)
        {
            return StepForDestination(Location, PacmanLocation);
        }//end Scatter

        //Поворот Призрака соотвественно его вектору движения
        override protected void Turning()
        {
            if (ImgGhost.Location.X == NextLocation.X)
                if (ImgGhost.Location.Y - NextLocation.Y < 0)
                    ImgGhost.Image = Properties.Resources.blinky3;//Смотрит вниз
                else
                    ImgGhost.Image = Properties.Resources.blinky4;//Смотрит вверх
            else
                if (ImgGhost.Location.X - NextLocation.X < 0)
                    ImgGhost.Image = Properties.Resources.blinky2; // Смотрит вправо
                else
                    ImgGhost.Image = Properties.Resources.blinky1; // Смотрит влево     
        }// end Turning()


        //Нет условий выхода
        protected override bool ExitConditions()
        {
            throw new NotImplementedException();
        }//end ExitConditions()

        //Нет нужды этой функции для данного класса
        protected override Point BaseStepForDestination(Point[] Location, Point Destination)
        {
            throw new NotImplementedException();
        }//end BaseStepForDestination
    }
}

