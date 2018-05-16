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

        public static List<Player> players = new List<Player>();
        Player player1;
        Player player2;
        static Button[,] buttons = new Button[5,5];
        public GameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            for(int i= 0; i<5; ++i)
            {
                for(int j=0; j<5; ++j)
                {
                    Button button = new Button
                    {
                        Height = BUTTON_HEIGHT,
                        Width = BUTTON_WIDTH
                    };
                    button.Location = new Point(i*button.Width, j*button.Height);
                    Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
            player1 = players[0];
            player2 = players[1];
            
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
