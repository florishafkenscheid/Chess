using ChessApp.Models.Pieces;

namespace ChessApp.Models.Board
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

        public void MovePiece(Tile to)
        {
            if (Piece == null)
            {
                throw new InvalidOperationException("Cannot move from an empty tile");
            }

            to.Piece = Piece;
            Piece = null;
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

            int parsedCol = char.ToLower(name[0]) - 'a';
            int parsedRank = 8 - int.Parse(name[1].ToString()); // -8 = Convert rank to code's row index

            return GetTileFromBoard(parsedRank, parsedCol);
        }

        // In Tile.cs
        public override string ToString()
        {
            int rank = 8 - Row; // Convert 0-based row to chess rank (e.g., Row 0 -> "8")
            return $"{(char)(Col + 'a')}{rank}";
        }
    }
}