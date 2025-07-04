﻿using ChessApp.Models.Board;
using ChessApp.Models.Moves;
using ChessApp.Services;
using ChessApp.Utils;

namespace ChessApp;

public partial class GameControl : UserControl
{
    private const int GridSize = 8;
    private readonly int squareSize = 50;
    private readonly Board gameBoard;
    private Utils.Color currentPlayerColor = Utils.Color.White; // Starting player is White
    private readonly LinkedList<Move> moveHistory;
    private readonly EngineOption[] engineOptions;
    private readonly List<Tile> highlightedTiles = [];
    private Tile? selectedTile;
    private StockfishService? stockfishService;
    private bool isResigned = false;

    public GameControl()
    {
        InitializeComponent();
        gameBoard = new Board(); // Initialize an empty board first
        moveHistory = Serializer.DeserializeMoveHistory() ?? new LinkedList<Move>();
        engineOptions = Serializer.DeserializeOptions() ?? [];
        if (moveHistory.Count > 0)
        {
            gameBoard = new Board(moveHistory); // Overwrite the board if there's a move history
            whiteLastMove.Text = moveHistory.Last.Value.ToString();
            if (moveHistory.Count > 1)
            {
                var secondToLastMove = moveHistory.Last.Previous.Value;
                BlackLastMove.Text = secondToLastMove.ToString();
            }
        }
        currentPlayerColor = gameBoard.ColorToMove; // If Board(fen) is called, this might be black, conflicting with the default set above

        InitializeStockfishAsync();

        MouseClick += new MouseEventHandler(Game_MouseClick);
    }

    private async void InitializeStockfishAsync()
    {
        await Task.Run(() =>
        {
            stockfishService = new StockfishService();

            for (int i = 0; i < engineOptions.Length; i++)
            {
                _ = stockfishService.SetOption(engineOptions[i]);
            }
        });
    }


    // Handle the drawing of the chessboard
    // In GameControl.cs
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                Tile tile = gameBoard.BoardState[row, col];

                // Draw tile background
                System.Drawing.Color bgColor = tile.Color == System.Drawing.Color.White ?
                    System.Drawing.Color.White : System.Drawing.Color.Gray;
                g.FillRectangle(new SolidBrush(bgColor), col * squareSize, row * squareSize, squareSize, squareSize);

                // Draw piece image if present
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
        if (e.X > squareSize * GridSize || e.Y > squareSize * GridSize)
        {
            return; // Click is outside the grid, do nothing
        }

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
            if (!isResigned)
            {
                if (fromTile.Piece != null && fromTile.Piece.Color == currentPlayerColor)
                {
                    selectedTile = fromTile;
                    //MessageBox.Show($"Selected {fromTile.Piece} at ({fromTile.Row}, {fromTile.Col})");
                    // Highlight the selected tile
                    HighlightValidMovesForSelectedTile(fromTile);

                }
                else
                {
                    MessageBox.Show("You cannot select an opponent's piece or an empty tile.");
                }
            }
            else
            {
                MessageBox.Show("You have resigned, you cannot select a piece.");
            }
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

            gameBoard.UpdateFromMove(recentMove);
            RedrawTiles(fromTile, toTile);

            currentPlayerColor = (currentPlayerColor == Utils.Color.White) ? Utils.Color.Black : Utils.Color.White;

            if (moveHistory.Count > 0)
            {
                if (currentPlayerColor != Utils.Color.White)
                {
                    whiteLastMove.Text = moveHistory.Last?.Value.ToString() ?? string.Empty;
                }
                else
                {
                    BlackLastMove.Text = moveHistory.Last?.Value.ToString() ?? string.Empty;
                }
            }

            // Check for check/checkmate after each move
            CheckGameState();

            // If it's now the AI's turn, make the AI move
            if (currentPlayerColor == Utils.Color.Black) // Assuming AI plays as Black
            {
                // Use Task.Run to avoid UI freezing while waiting for Stockfish
                Task.Run(() =>
                {
                    // Need to use Invoke since we're updating UI from a different thread
                    Invoke((MethodInvoker)async delegate
                    {
                        await MakeStockfishMove();
                    });
                });
            }
        }
        else
        {
            MessageBox.Show($"Invalid move {new Move(fromTile, toTile)}");
            ClearHighlightedTiles();
        }
    }

    private void RedrawTiles(Tile? fromTile, Tile toTile)
    {
        using Graphics g = this.CreateGraphics();
        // Redraw the clicked tile
        RedrawTile(g, toTile);
        // Clear highlighted tiles
        ClearHighlightedTiles();
        // Redraw the source tile if it exists
        if (fromTile != null)
        {
            RedrawTile(g, fromTile);
        }
    }

    private void HighlightValidMovesForSelectedTile(Tile selectedTile)
    {
        using Graphics g = this.CreateGraphics();

        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                Tile toTile = gameBoard.BoardState[row, col];
                if (selectedTile.Piece != null && selectedTile.Piece.IsValidMove(selectedTile, toTile, gameBoard))
                {
                    highlightedTiles.Add(toTile);
                    g.FillRectangle(new SolidBrush(System.Drawing.Color.LightGreen), col * squareSize, row * squareSize, squareSize, squareSize);
                }
            }
        }
    }
    private void ClearHighlightedTiles()
    {
        using Graphics g = this.CreateGraphics();
        foreach (Tile tile in highlightedTiles)
        {
            RedrawTile(g, tile);

        }
        highlightedTiles.Clear();
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

        string currentFen = gameBoard.ToString();
        await stockfishService.SetPosition(currentFen);

        Move bestMove = await stockfishService.GetBestMove();

        MovePiece(bestMove.From, bestMove.To);
    }

    private void CheckGameState()
    {
        // Check if the current player is in check
        bool isInCheck = gameBoard.IsInCheck(currentPlayerColor);

        // Check if the current player is in checkmate
        if (isInCheck && gameBoard.IsCheckmate(currentPlayerColor))
        {
            // Get the winning color (opposite of current player)
            Utils.Color winningColor = currentPlayerColor == Utils.Color.White ? Utils.Color.Black : Utils.Color.White;
            label4.Text = $"{currentPlayerColor} is in checkmate";
            MessageBox.Show($"Checkmate! {winningColor} wins the game.");
            Serializer.ClearMoves();
        }
        else if (isInCheck)
        {
            MessageBox.Show($"{currentPlayerColor} is in check!");
        }

        if (!gameBoard.IsCheckmate(currentPlayerColor) && !gameBoard.IsInCheck(currentPlayerColor))
        {
            label4.Text = "currently playing";
        }
        else if (gameBoard.IsInCheck(currentPlayerColor))
        {
            label4.Text = $"{currentPlayerColor} is in check";
        }
    }

    private void roundButton2_Click(object sender, EventArgs e)
    {
        if (isResigned == false)
        {
            MessageBox.Show("You have resigned");
            isResigned = true;
            // Clear the move history
            Serializer.ClearMoves();
        }
        else
        {
            Form1 form1 = new Form1();
            form1.FormClosed += (s, args) => Application.Exit();
            this.FindForm()?.Hide();
            form1.Show();
        }
    }

    private void roundButton3_Click(object sender, EventArgs e)
    {
        Form1 form1 = new Form1();
        form1.FormClosed += (s, args) => Application.Exit();
        this.FindForm()?.Hide();
        form1.Show();
    }
}