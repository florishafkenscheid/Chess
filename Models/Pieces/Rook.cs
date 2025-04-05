using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    public class Rook(Utils.Color color) : Piece(color)
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board.Board board) => MoveValidator.IsStraightValid(startTile, endTile, board, Color);
    }
}
