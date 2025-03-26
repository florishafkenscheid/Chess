using System;
using System.Drawing;
using System.Windows.Forms;
using ChessApp.Models;
using ChessApp.Models.Moves;
using ChessApp.Pieces;
using ChessApp.Utils;

namespace ChessApp
{
    public partial class GameControl : UserControl
    {
        private const int GridSize = 8;
        private int squareSize;
        private Board gameBoard;
        private Piece? selectedPiece = null;
        private Tile? selectedTile = null;
        private Utils.Color currentPlayerColor = Utils.Color.White; // Starting player is White
        private LinkedList<Move> moveHistory = new();

        public GameControl(string? fen = null)
        {
            InitializeComponent();
            squareSize = 100; // Square size
            gameBoard = fen == null ? new Board() : new Board(fen);
            currentPlayerColor = gameBoard.ColorToMove; // If Board(fen) is called, this might be black, conflicting with the default set above

            this.MouseClick += new MouseEventHandler(game_MouseClick);
        }

        // Handle the drawing of the chessboard
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Loop through each tile on the board
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Tile tile = gameBoard.BoardState[row, col];

                    // Draw the tile
                    System.Drawing.Color color = tile.Color;
                    g.FillRectangle(new SolidBrush(color), col * squareSize, row * squareSize, squareSize, squareSize);

                    if (tile.Piece != null)
                    {
                        Image pieceImage = Image.FromFile($"Images/{tile.Piece.ToString()}.png");
                        g.DrawImage(pieceImage, col * squareSize, row * squareSize, squareSize, squareSize);
                    }
                }
            }
        }

        private void game_MouseClick(object? sender, MouseEventArgs e)
        {
            int col = e.X / squareSize;
            int row = e.Y / squareSize;

            Tile clickedTile = gameBoard.BoardState[row, col];

            // If no piece is selected, select the piece
            if (selectedPiece == null)
            {
                if (clickedTile.Piece != null)
                {
                    // Only select if the piece belongs to the current player
                    if (clickedTile.Piece.Color == currentPlayerColor)
                    {
                        selectedPiece = clickedTile.Piece;
                        selectedTile = clickedTile;
                        MessageBox.Show($"Selected {selectedPiece} at ({row}, {col})");
                    }
                    else
                    {
                        MessageBox.Show("You cannot select an opponent's piece.");
                    }
                }
            }
            else
            {
                // If a piece is selected, check if the move is valid
                if (selectedTile != null && selectedPiece.IsValidMove(selectedTile, clickedTile, gameBoard))
                {
                    moveHistory.AddLast(new Move(selectedTile, clickedTile));
                    Serializer.Write(moveHistory);

                    clickedTile.Piece = selectedPiece;
                    selectedTile.Piece = null;

                    selectedPiece = null;
                    selectedTile = null;

                    // Change turn to the other player
                    currentPlayerColor = (currentPlayerColor == Utils.Color.White) ? Utils.Color.Black : Utils.Color.White;

                    MessageBox.Show($"Moved {selectedPiece} to ({row}, {col})");
                }
                else
                {
                    MessageBox.Show("Invalid move");
                    // Deselect the piece and tile if the move is invalid
                    selectedPiece = null;
                    selectedTile = null;
                }
            }

            this.Invalidate();
        }
    }
}
