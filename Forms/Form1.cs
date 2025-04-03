namespace ChessApp
{
    public partial class Form1 : Form
    {
        private static Options? optionsWindow = null;

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
            GameControl gameControl = new()
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Clear();
            this.Controls.Add(gameControl);

        }

        private void OpenOptionsWindow()
        {
            if (optionsWindow == null || optionsWindow.IsDisposed)
            {
                optionsWindow = new Options();
                optionsWindow.Show();
            }
            else
            {
                optionsWindow.BringToFront(); // If the window is already open, bring it to the front
            }
        }
        private void roundButton2_Click(object sender, EventArgs e)
        {
            OpenOptionsWindow();
        }

    }
}
