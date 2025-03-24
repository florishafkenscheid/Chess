using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessApp.pieces;

namespace ChessApp
{
    public partial class GameControl : UserControl
    {
        private const int GridSize = 8;
        private int squareSize;
        private Piece[,] board;
        private Piece selectedPiece = null;
        private int startRow, startCol;
        public GameControl()
        {
            InitializeComponent();
            squareSize = 100; // Square size based on form width
            InitializeBoard();
            this.MouseClick += new MouseEventHandler(game_MouseClick);
        }
        private void InitializeBoard()
        {
            // Initialize an 8x8 chessboard with pieces at starting positions
            board = new Piece[GridSize, GridSize]
   {
        { new Rook("Black"), new Knight("Black"), new Bishop("Black"), new Queen("Black"), new King("Black"), new Bishop("Black"), new Knight("Black"), new Rook("Black") },
        { new Pawn("Black"), new Pawn("Black"), new Pawn("Black"), new Pawn("Black"), new Pawn("Black"), new Pawn("Black"), new Pawn("Black"), new Pawn("Black") },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn("White"), new Pawn("White"), new Pawn("White"), new Pawn("White"), new Pawn("White"), new Pawn("White"), new Pawn("White"), new Pawn("White") },
        { new Rook("White"), new Knight("White"), new Bishop("White"), new Queen("White"), new King("White"), new Bishop("White"), new Knight("White"), new Rook("White") }
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
                    Piece piece = board[row, col];
                    if (piece != null)
                    {
                        Image pieceImage = Image.FromFile($"Images/{piece.ToString()}.png");
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

            if (selectedPiece == null)
            {
                // Select the piece
                selectedPiece = board[row, col];
                startRow = row;
                startCol = col;

                if (selectedPiece != null)
                {
                    MessageBox.Show($"Selected {selectedPiece.ToString()} at ({startRow}, {startCol})");
                }
            }
            else
            {
                // Move the piece
                if (selectedPiece.IsValidMove(startRow, startCol, row, col, board))
                {
                    board[row, col] = selectedPiece;
                    board[startRow, startCol] = null; // Clear the old position

                    selectedPiece = null; // Deselect the piece

                    // Trigger a redraw of the board
                    this.Invalidate(); // Redraw the board to show the moved piece
                }
                else
                {
                    MessageBox.Show("Invalid move");
                }

                selectedPiece = null; // Deselect the piece
            }
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
         

        }
    }
}
