using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    internal abstract class Piece(Utils.Color color)
    {
        public Utils.Color Color = color;
    }
}
