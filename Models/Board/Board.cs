﻿using System.Text;
using ChessApp.Models.Moves;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Models.Board
{
    public class Board
    {
        public const int GRID_SIZE = 8;
        public Tile[,] BoardState { get; private set; }
        public Utils.Color ColorToMove { get; private set; }
        // Castling
        // En passant
        // Half move clock
        // Full move number

        public Board()
        {
            BoardState = InitializeBoard();
            ColorToMove = Utils.Color.White;

            InitializeTileAccess();
        }

        public Board(string fen)
        {
            BoardState = InitializeBoardFromFen(fen);

            InitializeTileAccess();
        }

        private void InitializeTileAccess()
        {
            Tile.RegisterBoardTileAccess((row, col) =>
            {
                if (row < 0 || row >= GRID_SIZE || col < 0 || col >= GRID_SIZE)
                {
                    throw new ArgumentOutOfRangeException("Row or column out of board range");
                }
                return BoardState[row, col];
            });
        }

        private Tile[,] InitializeBoard()
        {
            Tile[,] boardState = new Tile[GRID_SIZE, GRID_SIZE];
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    boardState[row, col] = new Tile(row, col);
                }
            }

            // Assign pieces to the appropriate tiles
            boardState[0, 0].Piece = new Rook(Utils.Color.Black);
            boardState[0, 1].Piece = new Knight(Utils.Color.Black);
            boardState[0, 2].Piece = new Bishop(Utils.Color.Black);
            boardState[0, 3].Piece = new Queen(Utils.Color.Black);
            boardState[0, 4].Piece = new King(Utils.Color.Black);
            boardState[0, 5].Piece = new Bishop(Utils.Color.Black);
            boardState[0, 6].Piece = new Knight(Utils.Color.Black);
            boardState[0, 7].Piece = new Rook(Utils.Color.Black);

            for (int i = 0; i < GRID_SIZE; i++)
            {
                boardState[1, i].Piece = new Pawn(Utils.Color.Black);
            }

            for (int i = 0; i < GRID_SIZE; i++)
            {
                boardState[6, i].Piece = new Pawn(Utils.Color.White);
            }

            boardState[7, 0].Piece = new Rook(Utils.Color.White);
            boardState[7, 1].Piece = new Knight(Utils.Color.White);
            boardState[7, 2].Piece = new Bishop(Utils.Color.White);
            boardState[7, 3].Piece = new Queen(Utils.Color.White);
            boardState[7, 4].Piece = new King(Utils.Color.White);
            boardState[7, 5].Piece = new Bishop(Utils.Color.White);
            boardState[7, 6].Piece = new Knight(Utils.Color.White);
            boardState[7, 7].Piece = new Rook(Utils.Color.White);

            return boardState;
        }

        private Tile[,] InitializeBoardFromFen(string fen)
        {
            Tile[,] boardState = new Tile[GRID_SIZE, GRID_SIZE];
            string[] fenParts = fen.Split('/', ' ');
            int row = 0;

            for (int i = 0; i < 8; i++) // 8 so it stops at fenParts[7], which is the last of the 8 rows. Information after that should be handled later
            {
                int col = 0;
                foreach (char symbol in fenParts[i])
                {
                    if (char.IsDigit(symbol))
                    {
                        int emptySpaces = int.Parse(symbol.ToString());
                        for (int j = 0; j < emptySpaces; j++)
                        {
                            boardState[row, col] = new Tile(row, col);
                            col++;
                        }
                    }
                    else
                    {
                        boardState[row, col] = new Tile(row, col);
                        boardState[row, col].Piece = PieceFromFenSymbol(symbol);
                        col++;
                    }
                }
                row++;
            }

            ColorToMove = fenParts[8] == "w" ? Utils.Color.White : Utils.Color.Black;  // Who to move
            // See comments near attributes for TODO

            return boardState;
        }

        private static Piece PieceFromFenSymbol(char symbol)
        {
            Utils.Color color = char.IsUpper(symbol) ? Utils.Color.White : Utils.Color.Black;
            symbol = char.ToLower(symbol);

            return symbol switch
            {
                'p' => new Pawn(color),
                'r' => new Rook(color),
                'n' => new Knight(color),
                'b' => new Bishop(color),
                'q' => new Queen(color),
                'k' => new King(color),
                _ => throw new ArgumentException("Invalid FEN symbol")
            };
        }

        public void UpdateFromMove(Move move, Utils.Color currentPlayerColor)
        {
            BoardState[move.To.Row, move.To.Col] = move.To;
            BoardState[move.From.Row, move.From.Col] = move.From;
            ColorToMove = ColorToMove == Utils.Color.White ? Utils.Color.Black : Utils.Color.White; // Toggle ColorToMove
        }

        public override string ToString() // thanks claude
        {
            StringBuilder fen = new();

            // 1. Piece placement (board representation)
            for (int row = 0; row < GRID_SIZE; row++)
            {
                int emptyCount = 0;

                for (int col = 0; col < GRID_SIZE; col++)
                {
                    Tile tile = BoardState[row, col];

                    if (tile.Piece == null)
                    {
                        emptyCount++;
                    }
                    else
                    {
                        // If there were empty squares before this piece, add the count
                        if (emptyCount > 0)
                        {
                            fen.Append(emptyCount);
                            emptyCount = 0;
                        }

                        // Add the piece representation
                        fen.Append(tile.Piece.ToFen());
                    }
                }

                // If there are empty squares at the end of the row
                if (emptyCount > 0)
                {
                    fen.Append(emptyCount);
                }

                // Add row separator (except after the last row)
                if (row < GRID_SIZE - 1)
                {
                    fen.Append('/');
                }
            }

            // 2. Active color
            fen.Append(' ');
            fen.Append(ColorToMove == Utils.Color.White ? 'w' : 'b');

            // 3. Castling rights (placeholder for now)
            fen.Append(" KQkq");

            // 4. En passant target square (placeholder for now)
            fen.Append(" -");

            // 5. Halfmove clock (placeholder for now)
            fen.Append(" 0");

            // 6. Fullmove number (placeholder for now)
            fen.Append(" 1");

            return fen.ToString();
        }
    }
}
