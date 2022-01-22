namespace WindowsFormsApplication1
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.checkSound = new System.Windows.Forms.CheckBox();
            this.comboBoxNumLevel = new System.Windows.Forms.ComboBox();
            this.labelNumLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnStart.Location = new System.Drawing.Point(12, 197);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(138, 52);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "СТАРТ";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnExit.Location = new System.Drawing.Point(554, 197);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(138, 52);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "ВЫХОД";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkSound
            // 
            this.checkSound.AutoSize = true;
            this.checkSound.BackColor = System.Drawing.Color.Transparent;
            this.checkSound.Checked = true;
            this.checkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSound.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkSound.Location = new System.Drawing.Point(616, 12);
            this.checkSound.Name = "checkSound";
            this.checkSound.Size = new System.Drawing.Size(76, 17);
            this.checkSound.TabIndex = 2;
            this.checkSound.Text = "Звук есть";
            this.checkSound.UseVisualStyleBackColor = false;
            this.checkSound.CheckedChanged += new System.EventHandler(this.checkSound_CheckedChanged);
            // 
            // comboBoxNumLevel
            // 
            this.comboBoxNumLevel.FormattingEnabled = true;
            this.comboBoxNumLevel.Location = new System.Drawing.Point(119, 170);
            this.comboBoxNumLevel.Name = "comboBoxNumLevel";
            this.comboBoxNumLevel.Size = new System.Drawing.Size(28, 21);
            this.comboBoxNumLevel.TabIndex = 3;
            // 
            // labelNumLevel
            // 
            this.labelNumLevel.AutoSize = true;
            this.labelNumLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelNumLevel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNumLevel.Location = new System.Drawing.Point(9, 173);
            this.labelNumLevel.Name = "labelNumLevel";
            this.labelNumLevel.Size = new System.Drawing.Size(104, 13);
            this.labelNumLevel.TabIndex = 4;
            this.labelNumLevel.Text = "Выберите уровень:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Title;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(704, 261);
            this.Controls.Add(this.labelNumLevel);
            this.Controls.Add(this.comboBoxNumLevel);
            this.Controls.Add(this.checkSound);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnStart);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 300);
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "FormMain";
            this.Text = "PackMan Ultimate";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.CheckBox checkSound;
        private System.Windows.Forms.ComboBox comboBoxNumLevel;
        private System.Windows.Forms.Label labelNumLevel;
    }
}

