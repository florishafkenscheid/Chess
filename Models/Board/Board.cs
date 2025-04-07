using System.Text;
using ChessApp.Models.Moves;
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Board;

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

        foreach (Move move in moveHistory)
        {
            UpdateFromMove(move);
        }
    }

    public void UpdateFromMove(Move move)
    {
        BoardState[move.To.Row, move.To.Col].Piece = move.From.Piece;
        BoardState[move.From.Row, move.From.Col].Piece = null;
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

    // Tijdsnood dus veel AI.
    public Tile FindKing(Utils.Color color)
    {
        for (int row = 0; row < GRID_SIZE; row++)
        {
            for (int col = 0; col < GRID_SIZE; col++)
            {
                Piece? piece = BoardState[row, col].Piece;
                if (piece is King && piece.Color == color)
                {
                    return BoardState[row, col];
                }
            }
        }
        throw new InvalidOperationException($"No {color} King found on the board");
    }

    public bool IsInCheck(Utils.Color color)
    {
        Tile kingTile = FindKing(color);
        Utils.Color opponentColor = color == Utils.Color.White ? Utils.Color.Black : Utils.Color.White;

        // Check if any opponent piece can capture the king
        for (int row = 0; row < GRID_SIZE; row++)
        {
            for (int col = 0; col < GRID_SIZE; col++)
            {
                Piece? piece = BoardState[row, col].Piece;
                if (piece != null && piece.Color == opponentColor)
                {
                    if (piece.IsValidMove(BoardState[row, col], kingTile, this))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public bool IsCheckmate(Utils.Color color)
    {
        // If not in check, can't be checkmate
        if (!IsInCheck(color))
        {
            return false;
        }

        // Try all possible moves for all pieces of the current player's color
        for (int fromRow = 0; fromRow < GRID_SIZE; fromRow++)
        {
            for (int fromCol = 0; fromCol < GRID_SIZE; fromCol++)
            {
                Piece? piece = BoardState[fromRow, fromCol].Piece;
                if (piece != null && piece.Color == color)
                {
                    // Try moving this piece to every possible square
                    for (int toRow = 0; toRow < GRID_SIZE; toRow++)
                    {
                        for (int toCol = 0; toCol < GRID_SIZE; toCol++)
                        {
                            // Skip invalid moves
                            if (!piece.IsValidMove(BoardState[fromRow, fromCol], BoardState[toRow, toCol], this))
                            {
                                continue;
                            }

                            // Try the move
                            bool canEscapeCheck = CanMovePreventCheck(BoardState[fromRow, fromCol], BoardState[toRow, toCol], color);
                            if (canEscapeCheck)
                            {
                                return false; // Found a move that prevents check, so it's not checkmate
                            }
                        }
                    }
                }
            }
        }

        // If we've checked all moves and none prevent check, it's checkmate
        return true;
    }

    private bool CanMovePreventCheck(Tile fromTile, Tile toTile, Utils.Color color)
    {
        // Save original state
        Piece? originalFromPiece = fromTile.Piece;
        Piece? originalToPiece = toTile.Piece;

        // Try making the move
        toTile.Piece = fromTile.Piece;
        fromTile.Piece = null;

        // Check if the king is still in check after the move
        bool stillInCheck = IsInCheck(color);

        // Restore original state
        fromTile.Piece = originalFromPiece;
        toTile.Piece = originalToPiece;

        // If not in check after the move, this move can prevent checkmate
        return !stillInCheck;
    }
}
