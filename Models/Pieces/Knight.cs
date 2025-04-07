using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Utils;
using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Pieces
{
    public class Knight(Utils.Color color) : Piece(color, 'n')
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board.Board board) => MoveValidator.IsKnightValid(startTile, endTile, board, Color);
    }
}
