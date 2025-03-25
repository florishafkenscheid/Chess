﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models;

namespace ChessApp.pieces
{
     
    
        public class King : Piece
        {
            public King(string color) : base(color) { }

            public override bool IsValidMove(Tile startTile, Tile endTile, Board board)
            {
            int startRow = startTile.Row;
            int startCol = startTile.Col;
            int endRow = endTile.Row;
            int endCol = endTile.Col;
            // The King moves one square in any direction
            int rowDiff = Math.Abs(startRow - endRow);
                int colDiff = Math.Abs(startCol - endCol);

                return rowDiff <= 1 && colDiff <= 1;
            }
        }
    

}
