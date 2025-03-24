namespace ChessApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            game game = new game();
            game.Show();

        }
    }
}
