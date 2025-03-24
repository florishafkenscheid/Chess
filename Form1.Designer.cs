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
            pictureBox1 = new PictureBox();
            roundButton1 = new RoundButton();
            roundButton2 = new RoundButton();
            roundButton3 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(815, 175);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 290);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.FromArgb(132, 221, 99);
            roundButton1.BorderColor = Color.Transparent;
            roundButton1.CornerRadius = 20;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton1.ForeColor = Color.White;
            roundButton1.Location = new Point(565, 487);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(784, 62);
            roundButton1.TabIndex = 2;
            roundButton1.Text = "Play";
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += roundButton1_Click;
            // 
            // roundButton2
            // 
            roundButton2.BackColor = Color.FromArgb(84, 84, 84);
            roundButton2.BorderColor = Color.Transparent;
            roundButton2.CornerRadius = 20;
            roundButton2.FlatStyle = FlatStyle.Flat;
            roundButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(565, 566);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(382, 62);
            roundButton2.TabIndex = 3;
            roundButton2.Text = "Options";
            roundButton2.UseVisualStyleBackColor = false;
            // 
            // roundButton3
            // 
            roundButton3.BackColor = Color.FromArgb(230, 95, 92);
            roundButton3.BorderColor = Color.Transparent;
            roundButton3.CornerRadius = 20;
            roundButton3.FlatStyle = FlatStyle.Flat;
            roundButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton3.ForeColor = Color.White;
            roundButton3.Location = new Point(967, 566);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(382, 62);
            roundButton3.TabIndex = 4;
            roundButton3.Text = "Quit";
            roundButton3.UseVisualStyleBackColor = false;
            roundButton3.Click += roundButton3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 240, 242);
            ClientSize = new Size(1894, 1009);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Controls.Add(roundButton1);
            Controls.Add(pictureBox1);
            Location = new Point(815, 175);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private RoundButton roundButton1;
        private RoundButton roundButton2;
        private RoundButton roundButton3;
    }
}
