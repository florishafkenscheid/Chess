﻿using ChessApp.pieces;

namespace ChessApp.Models
{
    public class Board
    {
        private const int GRID_SIZE = 8;
        public Tile[,] BoardState { get; private set; }

        public Board()
        {
            BoardState = InitializeBoard();

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
            string[] fenParts = fen.Split('/');
            int row = 0;

            foreach (string fenPart in fenParts)
            {
                int col = 0;
                foreach (char symbol in fenPart)
                {
                    if (char.IsDigit(symbol))
                    {
                        int emptySpaces = int.Parse(symbol.ToString());
                        for (int i = 0; i < emptySpaces; i++)
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

            return boardState;
        }

        private Piece PieceFromFenSymbol(char symbol)
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
    }
}
