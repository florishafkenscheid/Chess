using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class Game : Form
    {
        private const int GridSize = 8;
        private int squareSize;
        private string[,] board;

        public Game()
        {
            InitializeComponent();
            squareSize = 100; // Square size based on form width
            InitializeBoard();
            this.MouseClick += new MouseEventHandler(game_MouseClick);
        }

        private void InitializeBoard()
        { // TODO!!
            // Initialize an 8x8 chessboard with pieces at starting positions
            board = new string[GridSize, GridSize]
            {
            { "black_Rook", "black_Knight", "black_Bishop", "black_Queen", "black_King", "black_Bishop", "black_Knight", "black_Rook" },
            { "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn", "black_Pawn" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "" },
            { "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn" },
            { "Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook" }
            };
        }

        // Handle the drawing of the chessboard
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw the chessboard grid
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Color color = (row + col) % 2 == 0 ? Color.White : Color.Gray;
                    g.FillRectangle(new SolidBrush(color), col * squareSize, row * squareSize, squareSize, squareSize);

                    // Draw the chess pieces
                    string piece = board[row, col];
                    if (!string.IsNullOrEmpty(piece))
                    {
                        Image pieceImage = Image.FromFile($"Images/{piece}.png"); // Assuming images like "Pawn.png"
                        g.DrawImage(pieceImage, col * squareSize, row * squareSize, squareSize, squareSize);
                    }
                }
            }
        }
        private void game_MouseClick(object sender, MouseEventArgs e)
        {
            // Determine the square clicked
            int col = e.X / squareSize;
            int row = e.Y / squareSize;

            MessageBox.Show($"You clicked on square ({row}, {col})");
            this.Invalidate(); // Redraw the board
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You resigned!");
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }

}
