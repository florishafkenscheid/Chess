using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;

namespace ChessApp.Pieces
{
    public class King : Piece
    {
        public King(Utils.Color color) : base(color, 'k') { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
        int startRow = startTile.Row;
        int startCol = startTile.Col;
        int endRow = endTile.Row;
        int endCol = endTile.Col;
        // The King moves one square in any direction
        int rowDiff = Math.Abs(startRow - endRow);
            int colDiff = Math.Abs(startCol - endCol);

            return rowDiff <= 1 && colDiff <= 1;
        }
    }
}
