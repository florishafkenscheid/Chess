namespace ChessApp
{
    partial class Options
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
            colorDialog1 = new ColorDialog();
            SkillLevelNumup = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ramNumericUpDown = new NumericUpDown();
            label3 = new Label();
            threadsNumericUpDown = new NumericUpDown();
            roundButton1 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)SkillLevelNumup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ramNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)threadsNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // SkillLevelNumup
            // 
            SkillLevelNumup.Location = new Point(447, 87);
            SkillLevelNumup.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            SkillLevelNumup.Name = "SkillLevelNumup";
            SkillLevelNumup.Size = new Size(240, 39);
            SkillLevelNumup.TabIndex = 0;
            SkillLevelNumup.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(445, 39);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 1;
            label1.Text = "Skill level value between 0-20";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 162);
            label2.Name = "label2";
            label2.Size = new Size(217, 32);
            label2.TabIndex = 3;
            label2.Text = "Hash value in MB's";
            // 
            // ramNumericUpDown
            // 
            ramNumericUpDown.Location = new Point(447, 210);
            ramNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            ramNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ramNumericUpDown.Name = "ramNumericUpDown";
            ramNumericUpDown.Size = new Size(240, 39);
            ramNumericUpDown.TabIndex = 2;
            ramNumericUpDown.UseWaitCursor = true;
            ramNumericUpDown.Value = new decimal(new int[] { 256, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(445, 309);
            label3.Name = "label3";
            label3.Size = new Size(98, 32);
            label3.TabIndex = 5;
            label3.Text = "Threads";
            // 
            // threadsNumericUpDown
            // 
            threadsNumericUpDown.Location = new Point(447, 357);
            threadsNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            threadsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            threadsNumericUpDown.Name = "threadsNumericUpDown";
            threadsNumericUpDown.Size = new Size(240, 39);
            threadsNumericUpDown.TabIndex = 4;
            threadsNumericUpDown.UseWaitCursor = true;
            threadsNumericUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // roundButton1
            // 
            roundButton1.BorderColor = Color.Transparent;
            roundButton1.CornerRadius = 40;
            roundButton1.Location = new Point(445, 505);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(296, 46);
            roundButton1.TabIndex = 6;
            roundButton1.Text = "Save settings";
            roundButton1.UseVisualStyleBackColor = true;
            roundButton1.Click += roundButton1_Click;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 630);
            Controls.Add(roundButton1);
            Controls.Add(label3);
            Controls.Add(threadsNumericUpDown);
            Controls.Add(label2);
            Controls.Add(ramNumericUpDown);
            Controls.Add(label1);
            Controls.Add(SkillLevelNumup);
            Name = "Options";
            Text = "options";
            ((System.ComponentModel.ISupportInitialize)SkillLevelNumup).EndInit();
            ((System.ComponentModel.ISupportInitialize)ramNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)threadsNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorDialog colorDialog1;
        private NumericUpDown SkillLevelNumup;
        private Label label1;
        private Label label2;
        private NumericUpDown ramNumericUpDown;
        private Label label3;
        private NumericUpDown threadsNumericUpDown;
        private RoundButton roundButton1;
    }
}