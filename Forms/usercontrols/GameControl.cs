using System;
using System.Drawing;
using System.Windows.Forms;
using ChessApp.Models;
using ChessApp.Models.Board;
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
        private Utils.Color currentPlayerColor = Utils.Color.White; // Starting player is White
        private readonly LinkedList<Move> moveHistory;
        private Tile? selectedTile;

        public GameControl(string? fen = null)
        {
            InitializeComponent();
            squareSize = 100; // Square size
            gameBoard = fen == null ? new Board() : new Board(fen);
            currentPlayerColor = gameBoard.ColorToMove; // If Board(fen) is called, this might be black, conflicting with the default set above
            moveHistory = Serializer.DeserializeMoveHistory() ?? new LinkedList<Move>();

            this.MouseClick += new MouseEventHandler(Game_MouseClick);
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

        private void Game_MouseClick(object? sender, MouseEventArgs e)
        {
            int col = e.X / squareSize;
            int row = e.Y / squareSize;

            Tile clickedTile = gameBoard.BoardState[row, col];

            if (selectedTile == null)
            {
                SelectPiece(clickedTile);
            }
            else
            {
                MovePiece(selectedTile, clickedTile);
                selectedTile = null;
            }

            this.Invalidate();
        }

        private void SelectPiece(Tile fromTile)
        {
            if (fromTile.Piece != null && fromTile.Piece.Color == currentPlayerColor)
            {
                selectedTile = fromTile;
                MessageBox.Show($"Selected {fromTile.Piece} at ({fromTile.Row}, {fromTile.Col})");
            }
            else
            {
                MessageBox.Show("You cannot select an opponent's piece or an empty tile.");
            }
        }

        private void MovePiece(Tile fromTile, Tile toTile)
        {
            if (fromTile.Piece != null && fromTile.Piece.IsValidMove(fromTile, toTile, gameBoard))
            {
                Move recentMove = new(fromTile, toTile);
                moveHistory.AddLast(recentMove);
                Serializer.Write(moveHistory);

                fromTile.MovePiece(toTile);
                gameBoard.UpdateFromMove(recentMove);

                currentPlayerColor = (currentPlayerColor == Utils.Color.White) ? Utils.Color.Black : Utils.Color.White;

                MessageBox.Show($"Moved {fromTile.Piece} to ({toTile.Row}, {toTile.Col})");
            }
            else
            {
                MessageBox.Show("Invalid move");
            }
        }
    }
}
