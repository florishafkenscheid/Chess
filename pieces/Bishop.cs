using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    public class Bishop : Piece
    {
        public Bishop(string color) : base(color) { }

        public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
        {
            // Bishops move diagonally, so the row and column change must be the same distance
            return Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol);
        }
    }
}
