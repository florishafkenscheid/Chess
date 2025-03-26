using ChessApp.pieces;

namespace ChessApp.Models
{
    public class Board
    {
        private const int GridSize = 8;
        public Tile[,] BoardState { get; private set; }

        public Board()
        {
            BoardState = InitializeBoard();

            // Register the tile access method
            Tile.RegisterBoardTileAccess((row, col) =>
            {
                if (row < 0 || row >= GridSize || col < 0 || col >= GridSize)
                {
                    throw new ArgumentOutOfRangeException("Row or column out of board range");
                }
                return BoardState[row, col];
            });
        }

        private Tile[,] InitializeBoard()
        {
            Tile[,] boardState = new Tile[GridSize, GridSize];
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
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

            for (int i = 0; i < GridSize; i++)
            {
                boardState[1, i].Piece = new Pawn(Utils.Color.Black);
            }

            for (int i = 0; i < GridSize; i++)
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
    }
}
