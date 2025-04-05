﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Utils;

namespace ChessApp.Models.Pieces
{
    public class Bishop(Utils.Color color) : Piece(color)
    {
        public override bool IsValidMove(Tile startTile, Tile endTile, Board.Board board) => MoveValidator.IsStraightValid(startTile, endTile, board, Color);
    }
}
