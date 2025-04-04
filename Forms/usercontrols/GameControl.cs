﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Moves;
using ChessApp.Pieces;
using ChessApp.Services;
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
        private StockfishService? stockfishService;

        public GameControl(string? fen = null)
        {
            InitializeComponent();
            squareSize = 100; // Square size
            gameBoard = fen == null ? new Board() : new Board(fen);
            currentPlayerColor = gameBoard.ColorToMove; // If Board(fen) is called, this might be black, conflicting with the default set above
            moveHistory = Serializer.DeserializeMoveHistory() ?? new LinkedList<Move>();
            InitializeStockfishAsync();

            MouseClick += new MouseEventHandler(Game_MouseClick);
        }
        private async void InitializeStockfishAsync()
        {
            await Task.Run(() =>
            {
                stockfishService = new StockfishService();
            });
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
                        Image pieceImage = Image.FromFile($"Images/{tile.Piece}.png");
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
                RedrawTiles(fromTile, toTile);

                currentPlayerColor = (currentPlayerColor == Utils.Color.White) ? Utils.Color.Black : Utils.Color.White;

                MessageBox.Show($"Moved {fromTile.Piece} to ({toTile.Row}, {toTile.Col})");

                // If it's now the AI's turn, make the AI move
                if (currentPlayerColor == Utils.Color.Black) // Assuming AI plays as Black
                {
                    // Use Task.Run to avoid UI freezing while waiting for Stockfish
                    Task.Run(() =>
                    {
                        // Need to use Invoke since we're updating UI from a different thread
                        Invoke((MethodInvoker) async delegate
                        {
                            await MakeStockfishMove();
                        });
                    });
                }
            }
            else
            {
                MessageBox.Show("Invalid move");
            }
        }

        private void RedrawTiles(Tile? fromTile, Tile toTile)
        {
            using Graphics g = this.CreateGraphics();
            // Redraw the clicked tile
            RedrawTile(g, toTile);

            // Redraw the source tile if it exists
            if (fromTile != null)
            {
                RedrawTile(g, fromTile);
            }
        }

        private void RedrawTile(Graphics g, Tile tile)
        {
            int col = tile.Col;
            int row = tile.Row;

            // Draw the tile background
            g.FillRectangle(new SolidBrush(tile.Color), col * squareSize, row * squareSize, squareSize, squareSize);

            // Draw the piece if present
            if (tile.Piece != null)
            {
                Image pieceImage = Image.FromFile($"Images/{tile.Piece}.png");
                g.DrawImage(pieceImage, col * squareSize, row * squareSize, squareSize, squareSize);
            }
        }

        private async Task MakeStockfishMove()
        {
            if (stockfishService == null)
            {
                MessageBox.Show("Stockfish engine is not yet initialized. Please try again in a moment.");
                return;
            }

            string currentFen = gameBoard.ToString(); // TODO
            await stockfishService.SetPosition(currentFen);

            Move bestMove = await stockfishService.GetBestMove();

            MovePiece(bestMove.From, bestMove.To);

        }
    }
}