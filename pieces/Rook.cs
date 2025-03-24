using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    public class Rook : Piece
    {
        public Rook(string color) : base(color) { }

        public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
        {
            return startRow == endRow || startCol == endCol; // Moves in straight lines
        }
    }
}
