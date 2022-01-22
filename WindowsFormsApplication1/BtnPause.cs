using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class BtnPause : Button
    {
        public BtnPause(int SizeX, int SizeY, System.Drawing.Point location)
        {
            this.SetStyle(ControlStyles.Selectable, false);
            this.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Batang", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.ForeColor = System.Drawing.Color.White;
            this.Location = location;
            this.Name = "btnPause";
            this.Size = new System.Drawing.Size(SizeX, SizeY);
            this.TabIndex = 5;
            this.Text = "Pause";
            this.UseVisualStyleBackColor = true;
            
            
        }

    }
}
