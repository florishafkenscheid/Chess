using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;
using ChessApp.Utils;

namespace ChessApp.pieces
{
    public class Bishop : Piece, IDiagonal
    {
        public Bishop(Utils.Color color) : base(color) { }

        public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
        {
            return IsValidDiagonal(startTile, endTile, board); 
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
