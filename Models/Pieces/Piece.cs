using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    public abstract class Piece(Utils.Color color)
    {
        public Utils.Color Color { get; } = color;

        // Abstract method to be implemented by specific piece types
        public abstract bool IsValidMove(Tile startTile, Tile endTile, Board.Board board);

        public override string ToString()
        {
            return $"{Color} {GetType().Name}";
        }
    }
}