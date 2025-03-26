using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board) => MoveValidator.IsStraightValid(startTile, endTile, board, this.Color);
    }
}
