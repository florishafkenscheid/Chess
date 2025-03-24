using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    public class Pawn : Piece
    {
        public Pawn(string color) : base(color) { }

        public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
        {
            int direction = (Color == "White") ? -1 : 1; // White moves up, Black moves down
            if (startCol == endCol && board[endRow, endCol] == null) // Normal move forward
            {
                return endRow == startRow + direction;
            }
            if (Math.Abs(startCol - endCol) == 1 && board[endRow, endCol] != null) // Capture move
            {
                return endRow == startRow + direction;
            }
            return false;
        }
    }
}
