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
            play_button = new Button();
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
            // play_button
            // 
            play_button.BackColor = Color.FromArgb(132, 221, 99);
            play_button.FlatAppearance.BorderSize = 0;
            play_button.FlatStyle = FlatStyle.Flat;
            play_button.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            play_button.ForeColor = Color.White;
            play_button.Location = new Point(568, 540);
            play_button.Name = "play_button";
            play_button.Size = new Size(784, 62);
            play_button.TabIndex = 1;
            play_button.Text = "Play";
            play_button.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 240, 242);
            ClientSize = new Size(1894, 1009);
            Controls.Add(play_button);
            Controls.Add(pictureBox1);
            Location = new Point(815, 175);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button play_button;
    }
}
