using ChessApp.Models.Board;

namespace ChessApp.Models.Pieces
{
    public abstract class Piece(Utils.Color color, char FenSymbol)
    {
        public Utils.Color Color { get; } = color;
        public char FenSymbol { get; set; } = FenSymbol;

        // Abstract method to be implemented by specific piece types
        public abstract bool IsValidMove(Tile startTile, Tile endTile, Board.Board board);

        public string ToFen()
        {
            return $"{(Color == Utils.Color.White ? char.ToUpper(FenSymbol) : char.ToLower(FenSymbol))}"; // uppercase if white, lowercase if black
        }

        public override string ToString()
        {
            return $"{Color} {GetType().Name}";
        }
    }
}
