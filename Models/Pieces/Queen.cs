using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.pieces
{
    public class Queen : Piece, IStraight, IDiagonal
    {
        public Queen(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            if (IsValidStraight(startTile, endTile, board) || IsValidDiagonal(startTile, endTile, board)) 
            {
                return true;
            }
            return false;
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

        public bool IsValidDiagonal(Tile startTile, Tile endTile, Board board)
        {
            int rowDiff = Math.Abs(startTile.Row - endTile.Row);
            int colDiff = Math.Abs(startTile.Col - endTile.Col);

            if (rowDiff != colDiff)
            {
                return false;
            }

            int rowStep = startTile.Row < endTile.Row ? 1 : -1;
            int colStep = startTile.Col < endTile.Col ? 1 : -1;

            int row = startTile.Row + rowStep;
            int col = startTile.Col + colStep;

            while (row != endTile.Row && col != endTile.Col)
            {
                if (board.BoardState[row, col].Piece != null)
                {
                    return false;
                }
                row += rowStep;
                col += colStep;
            }

            Piece? destinationPiece = board.BoardState[endTile.Row, endTile.Col].Piece;
            if (destinationPiece != null && destinationPiece.Color == this.Color)
            {
                return false;
            }

            return true;
        }
    }
}
