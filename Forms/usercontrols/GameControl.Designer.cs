using ChessApp.Utils;

namespace ChessApp
{
    partial class GameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roundButton3 = new RoundButton();
            roundButton2 = new RoundButton();
            whiteLastMove = new TextBox();
            BlackLastMove = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
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
            roundButton3.TabIndex = 4;
            roundButton3.Text = "Home";
            roundButton3.UseVisualStyleBackColor = false;
            roundButton3.Click += roundButton3_Click;
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
            roundButton2.TabIndex = 3;
            roundButton2.Text = "Resign";
            roundButton2.UseVisualStyleBackColor = false;
            roundButton2.Click += roundButton2_Click;
            // 
            // whiteLastMove
            // 
            whiteLastMove.Location = new Point(999, 130);
            whiteLastMove.Name = "whiteLastMove";
            whiteLastMove.ReadOnly = true;
            whiteLastMove.Size = new Size(200, 39);
            whiteLastMove.TabIndex = 5;
            // 
            // BlackLastMove
            // 
            BlackLastMove.Location = new Point(1620, 130);
            BlackLastMove.Name = "BlackLastMove";
            BlackLastMove.ReadOnly = true;
            BlackLastMove.Size = new Size(200, 39);
            BlackLastMove.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(999, 83);
            label1.Name = "label1";
            label1.Size = new Size(188, 32);
            label1.TabIndex = 7;
            label1.Text = "White last Move";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1620, 83);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 7;
            label2.Text = "Black last move";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 80F);
            label3.Location = new Point(1353, 433);
            label3.Name = "label3";
            label3.Size = new Size(0, 283);
            label3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 25F);
            label4.Location = new Point(999, 411);
            label4.Name = "label4";
            label4.Size = new Size(65, 89);
            label4.TabIndex = 9;
            label4.Text = "-";
            // 
            // GameControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BlackLastMove);
            Controls.Add(whiteLastMove);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Name = "GameControl";
            Size = new Size(1920, 1080);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton3;
        private RoundButton roundButton2;
        private TextBox whiteLastMove;
        private TextBox BlackLastMove;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
