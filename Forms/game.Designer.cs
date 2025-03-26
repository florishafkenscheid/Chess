namespace ChessApp
{
    partial class Game
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
            roundButton2 = new RoundButton();
            roundButton3 = new RoundButton();
            SuspendLayout();
            // 
            // roundButton2
            // 
            roundButton2.BackColor = Color.FromArgb(230, 95, 92);
            roundButton2.BorderColor = Color.Transparent;
            roundButton2.CornerRadius = 40;
            roundButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(968, 868);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(903, 65);
            roundButton2.TabIndex = 1;
            roundButton2.Text = "Resign";
            roundButton2.UseVisualStyleBackColor = false;
            roundButton2.Click += roundButton2_Click;
            // 
            // roundButton3
            // 
            roundButton3.BackColor = Color.FromArgb(84, 84, 84);
            roundButton3.BorderColor = Color.Transparent;
            roundButton3.CornerRadius = 40;
            roundButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton3.ForeColor = Color.White;
            roundButton3.Location = new Point(968, 783);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(903, 65);
            roundButton3.TabIndex = 2;
            roundButton3.Text = "Home";
            roundButton3.UseVisualStyleBackColor = false;
            roundButton3.Click += roundButton3_Click;
            // 
            // game
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 1009);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Name = "game";
            Text = "game";
            ResumeLayout(false);
        }

        #endregion
        private RoundButton roundButton2;
        private RoundButton roundButton3;
    }
}