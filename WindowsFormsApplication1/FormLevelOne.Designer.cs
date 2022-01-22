namespace WindowsFormsApplication1
{
    partial class FormLevelOne
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNumScore = new System.Windows.Forms.Label();
            this.lblDark1 = new System.Windows.Forms.Label();
            this.lblDark2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(449, 121);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score:";
            // 
            // lblNumScore
            // 
            this.lblNumScore.AutoSize = true;
            this.lblNumScore.Location = new System.Drawing.Point(493, 121);
            this.lblNumScore.Name = "lblNumScore";
            this.lblNumScore.Size = new System.Drawing.Size(25, 13);
            this.lblNumScore.TabIndex = 2;
            this.lblNumScore.Text = "000";
            // 
            // lblDark1
            // 
            this.lblDark1.AutoSize = true;
            this.lblDark1.BackColor = System.Drawing.Color.Black;
            this.lblDark1.Location = new System.Drawing.Point(80, 235);
            this.lblDark1.MinimumSize = new System.Drawing.Size(20, 20);
            this.lblDark1.Name = "lblDark1";
            this.lblDark1.Size = new System.Drawing.Size(20, 20);
            this.lblDark1.TabIndex = 3;
            // 
            // lblDark2
            // 
            this.lblDark2.AutoSize = true;
            this.lblDark2.BackColor = System.Drawing.Color.Black;
            this.lblDark2.Location = new System.Drawing.Point(440, 235);
            this.lblDark2.MinimumSize = new System.Drawing.Size(20, 20);
            this.lblDark2.Name = "lblDark2";
            this.lblDark2.Size = new System.Drawing.Size(20, 20);
            this.lblDark2.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimer.Location = new System.Drawing.Point(250, 10);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(60, 20);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Text = "00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormLevelOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(544, 487);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblDark2);
            this.Controls.Add(this.lblDark1);
            this.Controls.Add(this.lblNumScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(560, 535);
            this.MinimumSize = new System.Drawing.Size(560, 486);
            this.Name = "FormLevelOne";
            this.Text = "Level Fucking One";
            this.Load += new System.EventHandler(this.FormLevelOne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNumScore;
        private System.Windows.Forms.Label lblDark1;
        private System.Windows.Forms.Label lblDark2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer2;
    }
}