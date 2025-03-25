using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.pieces
{
    public abstract class Piece
    {
        public Utils.Color Color { get; }

        protected Piece(Utils.Color color)
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
