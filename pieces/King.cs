using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
     
    
        public class King : Piece
        {
            public King(string color) : base(color) { }

            public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
            {
                // The King moves one square in any direction
                int rowDiff = Math.Abs(startRow - endRow);
                int colDiff = Math.Abs(startCol - endCol);

                return rowDiff <= 1 && colDiff <= 1;
            }
        }
    

}
