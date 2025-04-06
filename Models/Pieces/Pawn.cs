using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Pieces
{
    public class Pawn(Utils.Color color) : Piece(color, 'p')
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;
            int direction = (Color == Utils.Color.White) ? -1 : 1; // White moves up, Black moves down

            // Ensure that the end tile is within bounds
            if (endRow < 0 || endRow >= 8 || endCol < 0 || endCol >= 8)
            {
                return false;
            }

            // pawn moves forward by 1 square if the destination is empty
            if (startCol == endCol && endTile.Piece == null)
            {
                if (endRow == startRow + direction)
                {
                    return true;
                }

                // pawn can move forward by 2 squares if both squares are empty for the first move
                if ((startRow == 6 && Color == Utils.Color.White) || (startRow == 1 && Color == Utils.Color.Black))
                {
                    if (endRow == startRow + 2 * direction && board.BoardState[startRow + direction, startCol].Piece == null)
                    {
                        return true;
                    }
                }
            }

            // pawn moves diagonally to capture an opponent's piece
            if (Math.Abs(startCol - endCol) == 1 && endTile.Piece != null)
            {
                Piece destinationPiece = endTile.Piece;
                if (endRow == startRow + direction && destinationPiece.Color != this.Color)
                {
                    return true;
                }
            }

            return false; 
        }
    }
}
