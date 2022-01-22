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
    public abstract class Being
    {
        protected const int Step = 1;// Интервал шага при движении
        public Timer AnimTimer = new Timer();  // Таймер шага и смены картинки существ
        protected const int TickTack = 1; // интервал тика таймера AnimTimer
        protected const int SizeBeing = 20;
        double DiagonalBeing = Math.Sqrt(2*Math.Pow(SizeBeing, 2));
        protected double Diagonal = SizeBeing * Math.Sqrt(2); //Диагональ Изображения Being
        protected int PiecesForEating = 80; //Количество пикселей пересечения Пакмана и Призрака, чтобы считать Пакмана съеденным
        protected Point StartLocation = new Point(260, 205);   //Начальная позиция Призрака, в которой первый раз входит в режим Преследования

        public Being()
        {            
            AnimTimer.Enabled = true;
        }//end Being()



        protected void CheckItem(int X, int Y, Control[] Item, out int Number)
        {
            Number = -1;
            //double diagonal;
            //double delta;

            //цикл по всем элементам
            for (int i = 0; i < Item.Length; i++)
            {

                //Если ширина элемента больше ширины Being
                if (Item[i].Width > SizeBeing)
                {
                    //Если хотя бы один из углов Being пересекаются с элементом
                    if (((Item[i].Location.X < X) && (X < Item[i].Location.X + Item[i].Width)) ||
                         ((Item[i].Location.X < X + SizeBeing) && (X + SizeBeing < Item[i].Location.X + Item[i].Width)))
                        //Если совпдает координата Y
                        if ((SizeBeing + Y == Item[i].Location.Y + 1) || (Y == Item[i].Location.Y + Item[i].Height - 1))
                        {
                            Number = i;
                            return;
                        }// end if
                }//end if
                    //Если ширина Being меньше ширины элемента
                else
                    //Если хотя бы один из углов Being пересекаются с элементом
                    if(((X < Item[i].Location.X )&&(  Item[i].Location.X < X + SizeBeing))  ||
                        ((X < Item[i].Location.X + Item[i].Width)&&(Item[i].Location.X + Item[i].Width < X + SizeBeing)))
                       //Если совпадает координата Y
                        if ((SizeBeing + Y == Item[i].Location.Y + 1) || (Y == Item[i].Location.Y + Item[i].Height - 1))
                        {
                            Number = i;
                            return;
                        }// end if

                //Если высота элемента больше высоты Being
                if (Item[i].Height > SizeBeing)
                {
                    //Если хотя бы один из углов Being пересекаются с элементом
                if (((Item[i].Location.Y < Y) && (Y < Item[i].Location.Y + Item[i].Height)) ||
                         ((Item[i].Location.Y < Y + SizeBeing) && (Y + SizeBeing < Item[i].Location.Y + Item[i].Height)))
                //Если совпадают координты X
                    if((X == Item[i].Location.X + Item[i].Width - 1 )||( X + SizeBeing == Item[i].Location.X + 1))
                    {
                        Number = i;
                        return;
                    }// end if

                }//end if
                    //Если высота элемента меньше высоты Being
                else
                    //Если хотя бы один из углов Being пересекаются с элементом
                     if (((Y < Item[i].Location.Y) && (Item[i].Location.Y < Y + SizeBeing)) ||
                         ((Y < Item[i].Location.Y + Item[i].Height) && (Item[i].Location.Y + Item[i].Height < Y + SizeBeing)))
                         //Если совпадают координты X
                         if ((X == Item[i].Location.X + Item[i].Width - 1) || (X + SizeBeing == Item[i].Location.X + 1))
                         {
                             Number = i;
                             return;
                         }// end if
                //Если высота одинаковая
                if (Item[i].Height == SizeBeing)
                {
                    //Если совпадают координаты Y
                    if (Item[i].Location.Y == Y) 
                        //Если совпадают координты X
                        if ((X == Item[i].Location.X + Item[i].Width - 1) || (X + SizeBeing == Item[i].Location.X + 1))
                        {
                            Number = i;
                            return;
                        }// end if
                }//end if
                //Если ширина одинаковая 
                if (Item[i].Width == SizeBeing)
                {
                    //Если Совпадают координаты X
                    if (Item[i].Location.X == X) 
                        //Если совпадают координаты Y
                        if ((SizeBeing + Y == Item[i].Location.Y + 1) || (Y == Item[i].Location.Y + Item[i].Height - 1))
                        {
                            Number = i;
                            return;
                        }// end if
                }//end if

            
                //diagonal = Math.Sqrt(Math.Pow(Item[i].Width, 2) + Math.Pow(Item[i].Height, 2));
                //if (diagonal < DiagonalBeing)
                //    diagonal = DiagonalBeing;
                //delta = Math.Sqrt(Math.Pow((X - Item[i].Location.X), 2) + Math.Pow((Y - Item[i].Location.Y), 2));
                //if (delta + 2 < diagonal)
                    //if (Item[i].Width * Item[i].Height <= SizeBeing * SizeBeing)
                    //{
                    //    for (int j = Item[i].Location.X; j <= Item[i].Location.X + Item[i].Width; j++)
                    //        for (int k = Item[i].Location.Y; k <= Item[i].Location.Y + Item[i].Height; k++)
                    //            if ((j > X) && (j < X + SizeBeing))
                    //                if ((k > Y) && (k < Y + SizeBeing))
                    //                {
                    //                    Number = i;
                    //                    return;
                    //                }// end if
                    //}
                    //else
                    //    for (int j = X; j <= X + SizeBeing; j++)
                    //        for (int k = Y; k <= Y + SizeBeing; k++)
                    //            if ((j > Item[i].Location.X) && (j < Item[i].Location.X + Item[i].Width))
                    //                if ((k > Item[i].Location.Y) && (k < Item[i].Location.Y + Item[i].Height))
                    //                {
                    //                    Number = i;
                    //                    return;
                    //                }// end if


                
            }//end for i
        }//end CheckItem()

        public void Pause()
        {
            if (AnimTimer.Enabled)
                AnimTimer.Enabled = false;
            else
                AnimTimer.Enabled = true;       
        }//end Pause()



    }
}
