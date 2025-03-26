using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.pieces
{
    public class Queen : Piece
    {
        public Queen(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board) =>
            MoveValidator.IsDiagonalValid(startTile, endTile, board, this.Color)
            || MoveValidator.IsDiagonalValid(startTile, endTile, board, this.Color);
    }
}
