using ChessApp.Utils;

namespace ChessApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PictureBox1 = new PictureBox();
            RoundButton1 = new RoundButton();
            RoundButton2 = new RoundButton();
            RoundButton3 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            PictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            PictureBox1.Location = new Point(815, 175);
            PictureBox1.Name = "pictureBox1";
            PictureBox1.Size = new Size(290, 290);
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // roundButton1
            // 
            RoundButton1.BackColor = System.Drawing.Color.FromArgb(132, 221, 99);
            RoundButton1.BorderColor = System.Drawing.Color.Transparent;
            RoundButton1.CornerRadius = 20;
            RoundButton1.FlatStyle = FlatStyle.Flat;
            RoundButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoundButton1.ForeColor = System.Drawing.Color.White;
            RoundButton1.Location = new Point(565, 487);
            RoundButton1.Name = "roundButton1";
            RoundButton1.Size = new Size(784, 62);
            RoundButton1.TabIndex = 2;
            RoundButton1.Text = "Play";
            RoundButton1.UseVisualStyleBackColor = false;
            RoundButton1.Click += RoundButton1_Click;
            // 
            // roundButton2
            // 
            RoundButton2.BackColor = System.Drawing.Color.FromArgb(84, 84, 84);
            RoundButton2.BorderColor = System.Drawing.Color.Transparent;
            RoundButton2.CornerRadius = 20;
            RoundButton2.FlatStyle = FlatStyle.Flat;
            RoundButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoundButton2.ForeColor = System.Drawing.Color.White;
            RoundButton2.Location = new Point(565, 566);
            RoundButton2.Name = "roundButton2";
            RoundButton2.Size = new Size(382, 62);
            RoundButton2.TabIndex = 3;
            RoundButton2.Text = "Options";
            RoundButton2.UseVisualStyleBackColor = false;
            RoundButton2.Click += RoundButton2_Click;
            // 
            // roundButton3
            // 
            RoundButton3.BackColor = System.Drawing.Color.FromArgb(230, 95, 92);
            RoundButton3.BorderColor = System.Drawing.Color.Transparent;
            RoundButton3.CornerRadius = 20;
            RoundButton3.FlatStyle = FlatStyle.Flat;
            RoundButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoundButton3.ForeColor = System.Drawing.Color.White;
            RoundButton3.Location = new Point(967, 566);
            RoundButton3.Name = "roundButton3";
            RoundButton3.Size = new Size(382, 62);
            RoundButton3.TabIndex = 4;
            RoundButton3.Text = "Quit";
            RoundButton3.UseVisualStyleBackColor = false;
            RoundButton3.Click += RoundButton3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(238, 240, 242);
            ClientSize = new Size(1894, 1009);
            Controls.Add(RoundButton3);
            Controls.Add(RoundButton2);
            Controls.Add(RoundButton1);
            Controls.Add(PictureBox1);
            Location = new Point(815, 175);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PictureBox1;
        private RoundButton RoundButton1;
        private RoundButton RoundButton2;
        private RoundButton RoundButton3;
    }
}
