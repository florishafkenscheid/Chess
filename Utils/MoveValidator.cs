﻿using ChessApp.Models;
using ChessApp.Pieces;

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

            while (currentRow != endTile.Row && currentCol != endTile.Col)
            {
                if (board.BoardState[currentRow, currentCol].Piece.HasValue)
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
                for (int col = startTile.Col + step; col != endTile.Col; col += step)
                {
                    if (board.BoardState[startTile.Row, col].Piece.HasValue)
                        return false;
                }
            }
            else
            {
                int step = startTile.Row < endTile.Row ? 1 : -1;
                for (int row = startTile.Row + step; row != endTile.Row; row += step)
                {
                    if (board.BoardState[row, startTile.Col].Piece.HasValue)
                        return false;
                }
            }

            return CheckDestination(endTile, board, color);
        }

        private static bool CheckDestination(Tile endTile, Board board, Color color)
        {
            Piece? destinationPiece = board.BoardState[endTile.Row, endTile.Col].Piece;
            return destinationPiece == null || destinationPiece.Color != color;
        }
    }
}