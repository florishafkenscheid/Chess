using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;

namespace ChessApp.pieces
{
    
        public class Queen : Piece
        {
            public Queen(string color) : base(color) { }

            public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
            {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;
            return startRow == endRow || startCol == endCol || Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol);//move like rook or bishop
            }
        }
    

}
