using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using project;

namespace WindowsFormsApplication1
{
    public class PackMan: Being
    {
        

        int NumWall = -1; // Номер стены перед Пакманом
        int NumTurn = 100; // Номер стены перед Пакманом, если он встанет в NextAngle
        public PictureBox ImgPacman = new PictureBox(); // Виджет для Пакмена
        int TicksForAnim;      
 public int Angle = 0;//угол по часовой стрелке
        int NextAngle = 0;
        public PackMan(System.Drawing.Point location) : base()
        {         
            ImgPacman.Location = location;
           
            ImgPacman.Size = new System.Drawing.Size(SizeBeing, SizeBeing);
            ImgPacman.BackColor = Color.Black;
            
            ImgPacman.Image = Properties.Resources.Cond1;
            
            ImgPacman.SizeMode = PictureBoxSizeMode.StretchImage;
            
            this.AnimTimer.Tick += new System.EventHandler(this.Tick);
            AnimTimer.Interval = TickTack;      
        }//end Pacman(Point location)

        //Позволяет Пакману двигать с помощью кнопок и вращает его в соответствии с направлением движения
        public void MoveAndRotate(KeyEventArgs e, Wall[] _Wall)
        {
            // Нажата кнопка влево
            if (e.KeyCode == Keys.Left)            
                NextAngle = 180;
               
            if (e.KeyCode == Keys.Right)           
                NextAngle = 0;        
            
            if (e.KeyCode == Keys.Down)          
                NextAngle = 90;
                            
            if (e.KeyCode == Keys.Up)
                NextAngle = 270;
            CheckWall(_Wall);
        }// end MoveAndRotate


        // Таймер по которому двигается Пакман, происходит анимация и разворот
        private void Tick(object AnimTimer, EventArgs e)
        {
            if (NumTurn < 0)
            {
                Angle = NextAngle;
                NewLocation(ImgPacman, NextAngle);
                NumTurn = 999;                
            }
            else
            // Если следующим шагом Пакман не врежется в стенку, то шаг 
            if (NumWall < 0)               
                NewLocation(ImgPacman,Angle);

            //Анимация Пакмана  и его разворот происходит на каждый 5-й тик
            TicksForAnim++;
            switch (TicksForAnim)
                {
                    case 0:
                        ImgPacman.Image = Properties.Resources.Cond3;
                        TicksForAnim++;
                        Switch();
                        break;
             
                    case 5:
                        ImgPacman.Image = Properties.Resources.Cond2;
                        TicksForAnim++;
                        Switch();
                        break;
              
                    case 10:
                        ImgPacman.Image = Properties.Resources.Cond1;
                        TicksForAnim++;
                        Switch();
                        break;
     
                    case 15:
                        ImgPacman.Image = Properties.Resources.Cond2;
                        TicksForAnim = -5;
                        Switch();
                        break;

                }//end switch
        }//end Tick()

        //Т.к. Все положения Пакмана находятся в положении нуля градусов их нужно развернуть
        private void Switch()
        {
            switch (Angle)
            {
                case 90:
                    ImgPacman.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    ImgPacman.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    ImgPacman.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }//end switch
        }//end Switch()


        // Функция, которая проверяет не врежется ли Пакман при следующем шаге в стену
        public void CheckWall(Wall[] _Wall)
        {

            switch (Angle)
            {
                case 0:
                    CheckItem(ImgPacman.Location.X + PackMan.Step, ImgPacman.Location.Y, _Wall, out NumWall);
                    break;
                case 90:
                    CheckItem(ImgPacman.Location.X, ImgPacman.Location.Y + PackMan.Step, _Wall, out  NumWall);
                    break;
                case 180:
                    CheckItem(ImgPacman.Location.X - PackMan.Step, ImgPacman.Location.Y, _Wall, out NumWall);
                    break;
                case 270:
                    CheckItem(ImgPacman.Location.X, ImgPacman.Location.Y - PackMan.Step, _Wall, out NumWall);
                    break;
            }
            if(!(NextAngle==Angle))
            switch (NextAngle)
            {
                case 0:
                    CheckItem(ImgPacman.Location.X + PackMan.Step, ImgPacman.Location.Y, _Wall, out NumTurn);
                    break;
                case 90:
                    CheckItem(ImgPacman.Location.X, ImgPacman.Location.Y + PackMan.Step, _Wall, out NumTurn);
                    break;
                case 180:
                    CheckItem(ImgPacman.Location.X - PackMan.Step, ImgPacman.Location.Y, _Wall, out NumTurn);
                    break;
                case 270:
                    CheckItem(ImgPacman.Location.X, ImgPacman.Location.Y - PackMan.Step, _Wall, out NumTurn);
                    break;
            }
        }// end CheckWall()

        public void CheckFood(Food[] _Food, out int NumberFood)
        {
            CheckItem(ImgPacman.Location.X, ImgPacman.Location.Y, _Food, out NumberFood);
        }//end CheckFood()

        public bool Dead(PictureBox Ghost)
        {
            //int NumberKiller;
            int k = 0; //Количество пикселей пересечения Призрака и Пакмана для засчета поражения
            double delta;
     
            delta = Math.Sqrt(Math.Pow((ImgPacman.Location.X - Ghost.Location.X), 2) + Math.Pow((ImgPacman.Location.Y - Ghost.Location.Y), 2));
            if (delta < Diagonal)
                for (int i = ImgPacman.Location.X; i <= ImgPacman.Location.X + SizeBeing; i++)
                    for (int j = ImgPacman.Location.Y; j <= ImgPacman.Location.Y + SizeBeing; j++)
                        if ((Ghost.Location.X < i) && ((Ghost.Location.X + SizeBeing) > i))
                            if ((Ghost.Location.Y < j) && ((Ghost.Location.Y + SizeBeing) > j))
                            {
                                k++;
                                if (k == PiecesForEating)
                                    //CheckItem(ImgPackman.Location.X + PackMan.Step, ImgPackman.Location.Y, Ghosts, out NumberKiller);
                                    //if (NumberKiller >= 0)
                                    return true; // Это плохая концовка
                            }
            //if (ImgPacman.Location == Ghost.Location)
            //    return true;
            
            return false; // А я еще живой...
        
        }//end Dead(PictureBox Ghost)

        protected void NewLocation(Control Image, int angle)
        {
            // Шаг происходит в ту сторону угла
            switch (angle)
            {
                case 0:
                    Image.Location = new Point(Image.Left + Step, Image.Top);
                    break;
                case 90:
                    Image.Location = new Point(Image.Left, Image.Top + Step);
                    break;
                case 180:
                    Image.Location = new Point(Image.Left - Step, Image.Top);
                    break;
                case 270:
                    Image.Location = new Point(Image.Left, Image.Top - Step);
                    break;
            }
        }// end NewLocation


        
        public void DeadAnim(int count)
        {
            switch (count)
            {
                case 0:
                    ImgPacman.Image = Properties.Resources.Cond3;
                    Switch();
                    break;

                case 1:
                    ImgPacman.Image = Properties.Resources.Cond2;
                    Switch();
                    break;

                case 2:
                    ImgPacman.Image = Properties.Resources.Cond1;
                    Switch();
                    break;

                case 3:
                    ImgPacman.Image = Properties.Resources.Cond4;
                    Switch();
                    break;
                case 4:
                    ImgPacman.Image = Properties.Resources.Cond5;
                    Switch();
                    break;
                case 5:
                    ImgPacman.Image = Properties.Resources.Cond6;
                    Switch();
                    break;
                case 6:
                    ImgPacman.Image = Properties.Resources.Cond7;
                    Switch();
                    break;
                case 7:
                    ImgPacman.Image = Properties.Resources.Cond8;
                    Switch();
                    break;
                case 8:
                    ImgPacman.Visible = false;
                    
                    ImgPacman.Location = new Point(600, 600);
                    Switch();
                    break;

            }//end switch
        }//end DeadAnim()
    }
}
