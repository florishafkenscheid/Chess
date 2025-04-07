using ChessApp.Models.Board;

namespace ChessApp.Models.Moves;

public class Move
{
    public Tile From { get; }
    public Tile To { get; }
    public char? Promotion { get; }

    public Move(string moveString)
    {
        From = Tile.FromAlgebraic(moveString.Substring(0, 2));
        To = Tile.FromAlgebraic(moveString.Substring(2, 2));
        Promotion = moveString.Length > 4 ? moveString[4] : (char?)null;
    }

    public Move(Tile from, Tile to) // TODO promotion
    {
        From = from;
        To = to;
        Promotion = null;
    }

    public override string ToString()
    { 
        return From.ToString() + To.ToString();
    }
}
