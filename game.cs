﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class game : Form
    {
        private const int GridSize = 8;
        private int squareSize;
        private string[,] board;

        public game()
        {
            InitializeComponent();
            squareSize = 100; // Square size based on form width
            InitializeBoard();
            this.MouseClick += new MouseEventHandler(game_MouseClick);

        }

        private void InitializeBoard()
        {
            // Initialize an 8x8 chessboard with pieces at starting positions
            board = new string[GridSize, GridSize]
            {
            { "black_Rook", "black_Knight", "black_Bishop", "black_Queen", "black_King", "black_Bishop", "black_Knight", "black_Rook" },
            { "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn" },
            { "Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook" }
            };
        }

        // Handle the drawing of the chessboard
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw the chessboard grid
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Color color = (row + col) % 2 == 0 ? Color.White : Color.Gray;
                    g.FillRectangle(new SolidBrush(color), col * squareSize, row * squareSize, squareSize, squareSize);

                    // Draw the chess pieces
                    string piece = board[row, col];
                    if (!string.IsNullOrEmpty(piece))
                    {
                        Image pieceImage = Image.FromFile($"Images/{piece}.png"); // Assuming images like "Pawn.png"
                        g.DrawImage(pieceImage, col * squareSize, row * squareSize, squareSize, squareSize);
                    }
                }
            }
        }
        private void game_MouseClick(object sender, MouseEventArgs e)
        {
            // Determine the square clicked
            int col = e.X / squareSize;
            int row = e.Y / squareSize;

            // You can implement logic here to select and move pieces
            // For example, highlight the clicked square or show the available moves for a piece
            MessageBox.Show($"You clicked on square ({row}, {col})");

            // Update the board if needed (e.g., move a piece, etc.)
            // For example, you could update the board array and call Invalidate() to redraw the board
            board[row, col] = "Pawn"; // Example move (replace with actual logic)
            this.Invalidate(); // Redraw the board
        }
    }

}
