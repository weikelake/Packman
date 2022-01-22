using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Wall : System.Windows.Forms.Control
    {
        public Wall(int width, int height, System.Drawing.Point location)
        {
            this.Width = width;
            this.Height = height;
            this.Location = location;
            this.BackColor = Wall_Color;
            this.Enabled = false;
        }

        System.Drawing.Color m_Wall_Color = System.Drawing.Color.FromArgb(30,100,254);
        public System.Drawing.Color Wall_Color
        {
            get
            {
                return m_Wall_Color;
            }
            set
            {
                m_Wall_Color = value;
            }
        }
    }
}
