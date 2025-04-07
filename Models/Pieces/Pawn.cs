using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    public class Pawn(Utils.Color color) : Piece(color, 'p')
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board.Board board) => MoveValidator.IsPawnValid(startTile, endTile, board, Color);
    }
}
