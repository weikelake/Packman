using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Food : System.Windows.Forms.Control
    {
       
        public Food(System.Drawing.Point location)
        {
            int size = 2;
            this.Width = size;
            this.Height = size;
            this.Location = location;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Enabled = false;
            this.Visible = true;
            this.BackColorChanged += new System.EventHandler(this._BackColorChanged);



        }




        private void _BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Black)
            {
                Sound.Food();
            }
        }

 



    }
}
