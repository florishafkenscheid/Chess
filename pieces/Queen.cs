using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    
        public class Queen : Piece
        {
            public Queen(string color) : base(color) { }

            public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
            {
                // The Queen can move like both a Rook and a Bishop: straight or diagonally
                return startRow == endRow || startCol == endCol || Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol);
            }
        }
    

}
