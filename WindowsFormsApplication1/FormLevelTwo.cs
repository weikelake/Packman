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
    public partial class FormLevelTwo : FormLevelOne
    {




        GhostBlue Inky = new GhostBlue(new Point(250, 240), new Point(440, 410));
        public FormLevelTwo()
        {
            InitializeComponent();
            Controls.Add(Inky.ImgGhost);
            Inky.GetWall(_Wall);
            Inky.ImgGhost.Move += new System.EventHandler(this.MoveGhost);
        }// end FormLevelTwo()


        protected override void InfoForGhost()
        {
            base.InfoForGhost();
            Inky.GetPacman(NewPackMan.ImgPacman.Location);
            Inky.GetPacmanAngle(NewPackMan.Angle);
            Inky.GetGhostRed(Blinky.ImgGhost.Location);
            Inky.GetScore(Score);
            
        }//end InfoForGhost

        protected override void InvisibleGhost()
        {
            Inky.ImgGhost.Visible = false;
            base.InvisibleGhost();
        }//end InfisibleGhost


        protected override void Pause()
        {
            Inky.Pause();
            base.Pause();
        }//end Pause()

   
    }
}
