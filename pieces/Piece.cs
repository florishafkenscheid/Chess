using ChessApp.Models;

namespace ChessApp.pieces
{
    public abstract class Piece
    {
        public string Color { get; }

        // Constructor to initialize the piece's color
        public Piece(string color)
        {
            Color = color;
        }

        // Abstract method to be implemented by specific piece types
        public abstract bool IsValidMove(Tile startTile, Tile endTile, Board board);

        public override string ToString()
        {
            return $"{Color} {GetType().Name}";
        }
    }
}
