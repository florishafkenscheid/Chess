using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Moves;
internal class Move
{
    public Tile From { get; }
    public Tile To { get; }
    public char? Promotion { get; }

    public Move(string moveString)
    {
        From = new Tile(moveString.Substring(0, 2));
        To = new Tile(moveString.Substring(2, 2));
        Promotion = moveString.Length > 4 ? moveString[4] : (char?)null;
    }
}
