using ChessApp.Models;
using ChessApp.Models.Board;
using ChessApp.Models.Pieces;

namespace ChessApp.Utils
{
    public static class MoveValidator
    {
        public static bool IsDiagonalValid(Tile startTile, Tile endTile, Board board, Color color)
        {
            int rowDiff = Math.Abs(startTile.Row - endTile.Row);
            int colDiff = Math.Abs(startTile.Col - endTile.Col);

            if (rowDiff != colDiff)
                return false;

            int rowStep = startTile.Row < endTile.Row ? 1 : -1;
            int colStep = startTile.Col < endTile.Col ? 1 : -1;

            int currentRow = startTile.Row + rowStep;
            int currentCol = startTile.Col + colStep;

            int maxRow = board.BoardState.GetLength(0) - 1;
            int maxCol = board.BoardState.GetLength(1) - 1;

            while (currentRow != endTile.Row && currentCol != endTile.Col)
            {
                // Check if current indices are within bounds
                if (currentRow < 0 || currentRow > maxRow || currentCol < 0 || currentCol > maxCol)
                    return false;

                if (board.BoardState[currentRow, currentCol].Piece != null)
                    return false;

                currentRow += rowStep;
                currentCol += colStep;
            }

            return CheckDestination(endTile, board, color);
        }

        public static bool IsStraightValid(Tile startTile, Tile endTile, Board board, Color color)
        {
            if (startTile.Row != endTile.Row && startTile.Col != endTile.Col)
                return false;

            if (startTile.Row == endTile.Row)
            {
                int step = startTile.Col < endTile.Col ? 1 : -1;

                int maxRow = board.BoardState.GetLength(0) - 1;

                for (int col = startTile.Col + step; col != endTile.Col; col += step)
                {
                    if (col < 0 || col > maxRow)
                        return false;

                    if (board.BoardState[startTile.Row, col].Piece != null)
                        return false;
                }
            }
            else
            {
                int step = startTile.Row < endTile.Row ? 1 : -1;
                for (int row = startTile.Row + step; row != endTile.Row; row += step)
                {
                    if (board.BoardState[row, startTile.Col].Piece != null)
                        return false;
                }
            }

            return CheckDestination(endTile, board, color);
        }

        public static bool IsKnightValid(Tile startTile, Tile endTile, Board board, Color color)
        {
            // two squares in one direction, then one square perpendicular
            int rowDiff = Math.Abs(startTile.Row - endTile.Row);
            int colDiff = Math.Abs(startTile.Col - endTile.Col);

            if ((rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2)) {
                return CheckDestination(endTile, board, color);
            }

            return false;
        }

        public static bool IsPawnValid(Tile startTile, Tile endTile, Board board, Color color)
        {
            int direction = color == Color.White ? -1 : 1;

            if (endTile.Row < 0 || endTile.Row >= 8 || endTile.Col < 0 || endTile.Col >= 8)
                return false;

            // Forward move
            if (startTile.Col == endTile.Col)
            {
                if (endTile.Piece != null)  // Can't move forward to occupied square
                    return false;

                if (endTile.Row == startTile.Row + direction)
                    return true;

                // Two-square initial move
                bool isInitialPosition = (color == Color.White && startTile.Row == 6) ||
                                       (color == Color.Black && startTile.Row == 1);

                if (isInitialPosition && endTile.Row == startTile.Row + 2 * direction)
                    return board.BoardState[startTile.Row + direction, startTile.Col].Piece == null;
            }

            // Diagonal capture
            if (Math.Abs(startTile.Col - endTile.Col) == 1 && endTile.Row == startTile.Row + direction)
            {
                return CheckDestination(endTile, board, color) && endTile.Piece != null;
            }

            return false;
        }

        public static bool IsKingValid(Tile startTile, Tile endTile, Board board, Color color)
        {
            // The King moves one square in any direction
            int rowDiff = Math.Abs(startTile.Row - endTile.Row);
            int colDiff = Math.Abs(startTile.Col - endTile.Col);

            return rowDiff <= 1 && colDiff <= 1 && CheckDestination(endTile, board, color);
        }

        private static bool CheckDestination(Tile endTile, Board board, Color color)
        {
            Piece? destinationPiece = board.BoardState[endTile.Row, endTile.Col].Piece;
            return destinationPiece == null || destinationPiece.Color != color;
        }
    }
}