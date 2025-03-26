using ChessApp.pieces;

namespace ChessApp.Models
{
    public class Tile
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Color Color { get; set; }
        public Piece? Piece { get; set; }  // The piece occupying the tile

        public Tile(int row, int col)
        {
            Row = row;
            Col = col;
            Color = (row + col) % 2 == 0 ? Color.White : Color.Gray;  // Set color for the board
            Piece = null;
        }

        public Tile(string name) // e2
        {
            if (name.Length != 2)
            {
                throw new ArgumentException("Name of tile too long, should be e.g. 'e2'");
            }

            // Get ascii code
            // Subtract it by something to get it to a=1, b=2...
            Col = char.ToLower(name[0]) - 'a' + 1;
            Row = int.Parse(name[1].ToString());

            Color = (Row + Col) % 2 == 0 ? Color.White : Color.Gray; // Set color for the board
            Piece = null;
        }
    }
}
