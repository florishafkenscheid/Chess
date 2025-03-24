using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.pieces
{
    
        public abstract class Piece
        {
            public string Color { get; } // "White" or "Black"

            public Piece(string color)
            {
                Color = color;
            }

            public abstract bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board);

            public override string ToString()
            {
                return $"{Color} {GetType().Name}"; // Returns something like "White Rook"
            }
        }

}
