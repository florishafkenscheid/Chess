using System.Security.Cryptography.X509Certificates;
using System.Text;
using ChessApp.Models.Moves;
using ChessApp.Models.Pieces;
using ChessApp.Utils;

namespace ChessApp.Models.Board
{
    public class Board
    {
        public const int GRID_SIZE = 8;
        public Tile[,] BoardState { get; private set; } = new Tile[GRID_SIZE, GRID_SIZE];
        public Utils.Color ColorToMove { get; private set; }
        // Castling
        // En passant
        // Half move clock
        // Full move number

        public Board()
        {
            InitializeTileAccess();
            InitializeBoard();
        }

        public Board(LinkedList<Move> moveHistory)
        {
            InitializeTileAccess();
            InitializeBoardFromMoveHistory(moveHistory);
        }

        private void InitializeTileAccess()
        {
            Tile.RegisterBoardTileAccess((row, col) =>
            {
                if (row < 0 || row >= GRID_SIZE || col < 0 || col >= GRID_SIZE)
                {
                    throw new ArgumentOutOfRangeException("Row or column out of board range");
                }
                return BoardState[row, col];
            });
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    BoardState[row, col] = new Tile(row, col);
                }
            }

            // Assign pieces to the appropriate tiles
            BoardState[0, 0].Piece = new Rook(Utils.Color.Black);
            BoardState[0, 1].Piece = new Knight(Utils.Color.Black);
            BoardState[0, 2].Piece = new Bishop(Utils.Color.Black);
            BoardState[0, 3].Piece = new Queen(Utils.Color.Black);
            BoardState[0, 4].Piece = new King(Utils.Color.Black);
            BoardState[0, 5].Piece = new Bishop(Utils.Color.Black);
            BoardState[0, 6].Piece = new Knight(Utils.Color.Black);
            BoardState[0, 7].Piece = new Rook(Utils.Color.Black);

            for (int i = 0; i < GRID_SIZE; i++)
            {
                BoardState[1, i].Piece = new Pawn(Utils.Color.Black);
            }

            for (int i = 0; i < GRID_SIZE; i++)
            {
                BoardState[6, i].Piece = new Pawn(Utils.Color.White);
            }

            BoardState[7, 0].Piece = new Rook(Utils.Color.White);
            BoardState[7, 1].Piece = new Knight(Utils.Color.White);
            BoardState[7, 2].Piece = new Bishop(Utils.Color.White);
            BoardState[7, 3].Piece = new Queen(Utils.Color.White);
            BoardState[7, 4].Piece = new King(Utils.Color.White);
            BoardState[7, 5].Piece = new Bishop(Utils.Color.White);
            BoardState[7, 6].Piece = new Knight(Utils.Color.White);
            BoardState[7, 7].Piece = new Rook(Utils.Color.White);

            ColorToMove = Utils.Color.White;
        }

        private void InitializeBoardFromMoveHistory(LinkedList<Move> moveHistory)
        {
            InitializeBoard();
            Utils.Color colorToMove = Utils.Color.White;
            foreach (Move move in moveHistory)
            {
                UpdateFromMove(move, colorToMove);
                colorToMove = colorToMove == Utils.Color.White ? Utils.Color.Black : Utils.Color.White;
            }
        }

        public void UpdateFromMove(Move move, Utils.Color currentPlayerColor)
        {
            BoardState[move.To.Row, move.To.Col].Piece = move.From.Piece;
            BoardState[move.From.Row, move.From.Col] = new Tile(move.From.Row, move.From.Col);
            ColorToMove = ColorToMove == Utils.Color.White ? Utils.Color.Black : Utils.Color.White; // Toggle ColorToMove
        }

        public override string ToString() // thanks claude
        {
            StringBuilder fen = new();

            // 1. Piece placement (board representation)
            for (int row = 0; row < GRID_SIZE; row++)
            {
                int emptyCount = 0;

                for (int col = 0; col < GRID_SIZE; col++)
                {
                    Tile tile = BoardState[row, col];

                    if (tile.Piece == null)
                    {
                        emptyCount++;
                    }
                    else
                    {
                        // If there were empty squares before this piece, add the count
                        if (emptyCount > 0)
                        {
                            fen.Append(emptyCount);
                            emptyCount = 0;
                        }

                        // Add the piece representation
                        fen.Append(tile.Piece.ToFen());
                    }
                }

                // If there are empty squares at the end of the row
                if (emptyCount > 0)
                {
                    fen.Append(emptyCount);
                }

                // Add row separator (except after the last row)
                if (row < GRID_SIZE - 1)
                {
                    fen.Append('/');
                }
            }

            // 2. Active color
            fen.Append(' ');
            fen.Append(ColorToMove == Utils.Color.White ? 'w' : 'b');

            // 3. Castling rights (placeholder for now)
            fen.Append(" KQkq");

            // 4. En passant target square (placeholder for now)
            fen.Append(" -");

            // 5. Halfmove clock (placeholder for now)
            fen.Append(" 0");

            // 6. Fullmove number (placeholder for now)
            fen.Append(" 1");

            return fen.ToString();
        }
    }
}
