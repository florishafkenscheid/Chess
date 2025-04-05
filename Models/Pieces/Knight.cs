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
    public class Knight : Piece
    {
        public Knight(Utils.Color color) : base(color, 'n') { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;
            // two squares in one direction, then one square perpendicular
            int rowDiff = Math.Abs(startRow - endRow);
            int colDiff = Math.Abs(startCol - endCol);

            return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
        }
    }
}
