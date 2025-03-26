using ChessApp.pieces;

namespace ChessApp.Models
{
    public class Tile
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Color Color { get; set; }  
        public Piece Piece { get; set; }  // The piece occupying the tile

        public Tile(int row, int col)
        {
            Row = row;
            Col = col;
            Color = (row + col) % 2 == 0 ? Color.White : Color.Gray;  // Set color for the board
            Piece = null;  // No piece initially
        }
    }
}
