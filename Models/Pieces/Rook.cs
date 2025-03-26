using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.pieces
{
    public class Rook : Piece, IStraight
    {
        public Rook(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            return IsValidStraight(startTile, endTile, board);
        }

        public bool IsValidStraight(Tile startTile, Tile endTile, Board board)
        {
            if (startTile.Row != endTile.Row && startTile.Col != endTile.Col)
            {
                return false;
            }

            // Check if the path is clear for horizontal or vertical move
            if (startTile.Row == endTile.Row) // Horizontal move
            {
                int step = startTile.Col < endTile.Col ? 1 : -1;
                for (int col = startTile.Col + step; col != endTile.Col; col += step)
                {
                    if (board.BoardState[startTile.Row, col].Piece != null) // Check if the tile has a piece
                    {
                        return false;
                    }
                }
            }
            else // Vertical move
            {
                int step = startTile.Row < endTile.Row ? 1 : -1;
                for (int row = startTile.Row + step; row != endTile.Row; row += step)
                {
                    if (board.BoardState[row, startTile.Col].Piece != null) // Check if the tile has a piece
                    {
                        return false;
                    }
                }
            }

            // Check if the destination is occupied by a piece of the same color
            Piece? destinationPiece = board.BoardState[endTile.Row, endTile.Col].Piece;
            if (destinationPiece != null && destinationPiece.Color == this.Color)
            {
                return false;
            }

            return true;
        }
    }
}
