using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Pieces
{
    public class Rook : Piece
    {
        public Rook(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board) => MoveValidator.IsStraightValid(startTile, endTile, board, this.Color);
    }
}
