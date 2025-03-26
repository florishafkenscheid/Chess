using ChessApp.Pieces;

namespace ChessApp.Models
{
    public class Tile
    {
        public static Func<int, int, Tile>? GetTileFromBoard { get; private set; }

        public int Row { get; private set; }
        public int Col { get; private set; }
        public Color Color { get; private set; }
        public Piece? Piece { get; set; } // Piece occupying the tile

        internal Tile(int row, int col)
        {
            Row = row;
            Col = col;
            Color = (row + col) % 2 == 0 ? Color.White : Color.Gray;
            Piece = null; // Default to empty
        }

        internal static void RegisterBoardTileAccess(Func<int, int, Tile> tileAccessFunc)
        {
            GetTileFromBoard = tileAccessFunc;
        }

        public static Tile FromAlgebraic(string name)
        {
            if (GetTileFromBoard == null)
            {
                throw new InvalidOperationException("Board must be initialized before accessing tiles.");
            }

            if (name.Length != 2)
            {
                throw new ArgumentException("Name of tile too long, should be e.g. 'e2'");
            }

            int col = char.ToLower(name[0]) - 'a';
            int row = 8 - int.Parse(name[1].ToString());

            return GetTileFromBoard(row, col);
        }

        public override string ToString()
        {
            return $"{(char)(Col + 'a')}{Row}";
        }
    }
}