using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    
        public class Knight : Piece
        {
            public Knight(string color) : base(color) { }

            public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
            {
                // Knights move in an "L" shape: two squares in one direction, then one square perpendicular
                int rowDiff = Math.Abs(startRow - endRow);
                int colDiff = Math.Abs(startCol - endCol);

                return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
            }
        }
    

}
