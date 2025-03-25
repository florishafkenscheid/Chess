using ChessApp.Models;

namespace ChessApp.pieces
{
    public class Rook : Piece
    {
        public Rook(string color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;

            // Rook moves in straight lines either horizontally or vertically
            if (startRow != endRow && startCol != endCol)
            {
                return false;
            }

            // Check if the path is clear for horizontal or vertical move
            if (startRow == endRow) // Horizontal move
            {
                int step = startCol < endCol ? 1 : -1;
                for (int col = startCol + step; col != endCol; col += step)
                {
                    if (board.BoardState[startRow, col].Piece != null) // Check if the tile has a piece
                    {
                        return false;
                    }
                }
            }
            else // Vertical move
            {
                int step = startRow < endRow ? 1 : -1;
                for (int row = startRow + step; row != endRow; row += step)
                {
                    if (board.BoardState[row, startCol].Piece != null) // Check if the tile has a piece
                    {
                        return false;
                    }
                }
            }

            // Check if the destination is occupied by a piece of the same color
            Piece destinationPiece = board.BoardState[endRow, endCol].Piece;
            if (destinationPiece != null && destinationPiece.Color == this.Color)
            {
                return false;
            }

            return true;
        }
    }
}
