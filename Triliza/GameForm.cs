using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triliza
{
    public partial class GameForm : Form
    {
        private const int BUTTON_HEIGHT = 70;
        private const int BUTTON_WIDTH = 70;

        private const int BOARD_WIDTH = 5;
        private const int BOARD_HEIGHT = 5;
        
        Player player1;
        Player player2;
        static Button[,] buttons = new Button[5,5];
        public GameForm()
        {
            InitializeComponent();
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateBoard();

            Options options = new Options();
            options.ShowDialog();
            try
            {
                player1 = options.player1;
                player2 = options.player2;
            }
            catch
            {
                Close();
            }
        }

        private void CreateBoard()
        {
            for (int i = 0; i < BOARD_WIDTH; ++i)
            {
                for (int j = 0; j < BOARD_HEIGHT; ++j)
                {
                    Button button = new Button
                    {
                        Height = BUTTON_HEIGHT,
                        Width = BUTTON_WIDTH
                    };
                    button.Location = new Point(i * button.Width, j * button.Height);
                    Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
