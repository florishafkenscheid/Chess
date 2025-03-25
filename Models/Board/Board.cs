using ChessApp.pieces;

namespace ChessApp.Models
{
    public class Board
    {
        private const int GridSize = 8;
        public Tile[,] BoardState { get; private set; }

        public Board()
        {
            InitializeBoard(); // Init the board
        }

        private void InitializeBoard()
        {
            BoardState = new Tile[GridSize, GridSize];
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    BoardState[row, col] = new Tile(row, col);  
                }
            }

            // Assign pieces to the appropriate tiles
            BoardState[0, 0].Piece = new Rook("Black");
            BoardState[0, 1].Piece = new Knight("Black");
            BoardState[0, 2].Piece = new Bishop("Black");
            BoardState[0, 3].Piece = new Queen("Black");
            BoardState[0, 4].Piece = new King("Black");
            BoardState[0, 5].Piece = new Bishop("Black");
            BoardState[0, 6].Piece = new Knight("Black");
            BoardState[0, 7].Piece = new Rook("Black");

            for (int i = 0; i < GridSize; i++)
            {
                BoardState[1, i].Piece = new Pawn("Black");
            }

            for (int i = 0; i < GridSize; i++)
            {
                BoardState[6, i].Piece = new Pawn("White");
            }

            BoardState[7, 0].Piece = new Rook("White");
            BoardState[7, 1].Piece = new Knight("White");
            BoardState[7, 2].Piece = new Bishop("White");
            BoardState[7, 3].Piece = new Queen("White");
            BoardState[7, 4].Piece = new King("White");
            BoardState[7, 5].Piece = new Bishop("White");
            BoardState[7, 6].Piece = new Knight("White");
            BoardState[7, 7].Piece = new Rook("White");
        }
    }
}
