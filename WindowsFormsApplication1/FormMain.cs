using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.PackManGreenIcon;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Обработчик события нажатия на кнопку button2
            Sound.PlayExit();
            Thread.Sleep(1000);
            Close();
        }

        private void checkSound_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!checkSound.Checked)
            {
                checkSound.Text = "Звука нет";
                
                Sound.SoundOff();
                
            }
            else
            {
             
                checkSound.Text = "Звук есть";
                Sound.SoundOn();
                
               
            }
            
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Обработчик нажатия на кнопку Старт
            Sound.PlayStart();
            int NumLevel;
            NumLevel = comboBoxNumLevel.SelectedIndex;
            Sound.PlayStart();
            switch (NumLevel + 1)
            {
                case 1:
                    FormLevelOne Level1 = new FormLevelOne();
                    Level1.ShowDialog(); 
                    break;
                case 2:
                    FormLevelTwo Level2 = new FormLevelTwo();
                    Level2.ShowDialog();
                    break;
                case 3:
                    FormLevelThree Level3 = new FormLevelThree();
                    Level3.ShowDialog();
                    break;
            }
            
        }
        
   

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxNumLevel.Items.Add("1");
            comboBoxNumLevel.Items.Add("2");
            comboBoxNumLevel.Items.Add("3");
            comboBoxNumLevel.SelectedIndex = 0;
        }
    }//end FormMain
}//end namespace WindowsFormsApplication1
