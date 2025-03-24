using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Board
{
    internal class Board
    {
        private Piece?[,] _board { get; set; }

        public Board()
        {
            _board = new Piece?[,] // From top left to bottom right
            {
                                { new Rook(Utils.Color.Black), new Knight(Utils.Color.Black), new Bishop(Utils.Color.Black), new Queen(Utils.Color.Black), new King(Utils.Color.Black), new Bishop(Utils.Color.Black), new Knight(Utils.Color.Black), new Rook(Utils.Color.Black) },
                                { new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black), new Pawn(Utils.Color.Black) },
                                { null, null, null, null, null, null, null, null },
                                { null, null, null, null, null, null, null, null },
                                { null, null, null, null, null, null, null, null },
                                { null, null, null, null, null, null, null, null },
                                { new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White), new Pawn(Utils.Color.White) },
                                { new Rook(Utils.Color.White), new Knight(Utils.Color.White), new Bishop(Utils.Color.White), new Queen(Utils.Color.White), new King(Utils.Color.White), new Bishop(Utils.Color.White), new Knight(Utils.Color.White), new Rook(Utils.Color.White) }
            };
        }

        public Board(string fen) // rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR
        {
            _board = new Piece?[8, 8]; // Grid size

            // Match letters to classes
            Dictionary<char, Func<Utils.Color, Piece>> matchingDict = new Dictionary<char, Func<Utils.Color, Piece>>() // Thanks copilot
                    {
                        { 'p', color => new Pawn(color) },
                        { 'r', color => new Rook(color) },
                        { 'n', color => new Knight(color) },
                        { 'b', color => new Bishop(color) },
                        { 'q', color => new Queen(color) },
                        { 'k', color => new King(color) },
                        { 'P', color => new Pawn(color) },
                        { 'R', color => new Rook(color) },
                        { 'N', color => new Knight(color) },
                        { 'B', color => new Bishop(color) },
                        { 'Q', color => new Queen(color) },
                        { 'K', color => new King(color) }
                    };

            string[] rows = fen.Split('/');
            for (int i = 0; i < rows.Length; i++)
            {
                int col = 0;
                foreach (char c in rows[i])
                {
                    if (char.IsDigit(c))
                    {
                        col += (int)char.GetNumericValue(c);
                    }
                    else
                    {
                        Utils.Color color = char.IsUpper(c) ? Utils.Color.White : Utils.Color.Black;
                        _board[i, col] = matchingDict[char.ToLower(c)](color);
                        col++;
                    }
                }
            }
        }
    }
}
