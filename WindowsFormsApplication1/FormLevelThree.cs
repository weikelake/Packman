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
    public partial class FormLevelThree : FormLevelTwo
    {
        GhostYellow Clyde = new GhostYellow(new Point(270, 240), new Point(99, 410));
        public FormLevelThree()
        {
            InitializeComponent();
            Controls.Add(Clyde.ImgGhost);
            Clyde.GetWall(_Wall);
            Clyde.ImgGhost.Move += new System.EventHandler(this.MoveGhost);
        }//end FormLevelThree

        protected override void InfoForGhost()
        {
            base.InfoForGhost();
            Clyde.GetPacman(NewPackMan.ImgPacman.Location);
            Clyde.GetScore(Score);
            
        }//end InfoForGhost

        protected override void InvisibleGhost()
        {
            Clyde.ImgGhost.Visible = false;   
            base.InvisibleGhost();

        }//end InvisibleGhost


        protected override  void Pause()
        {
            Clyde.Pause();
            base.Pause();
        }//end Pause()



    }
}
