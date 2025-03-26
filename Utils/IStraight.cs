using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;

namespace ChessApp.Utils
{
    internal interface IStraight
    {
        bool IsValidStraight(Tile startTile, Tile endTile, Board board);
    }
}
