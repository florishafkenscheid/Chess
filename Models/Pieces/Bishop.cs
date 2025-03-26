using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;

namespace ChessApp.pieces
{
    public class Bishop : Piece
    {
        public Bishop(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;
            // Bishops move diagonally
            return Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol);
        }
    }
}
