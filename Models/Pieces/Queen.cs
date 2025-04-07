using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    public class Queen(Utils.Color color) : Piece(color, 'q')
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board.Board board) =>
            MoveValidator.IsStraightValid(startTile, endTile, board, Color)
            || MoveValidator.IsDiagonalValid(startTile, endTile, board, Color);
    }
}
