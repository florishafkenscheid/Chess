using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;

namespace ChessApp.Utils
{
    internal interface IDiagonal
    {
        bool IsValidDiagonal(Tile startTile, Tile endTile, Board board);
    }
}
