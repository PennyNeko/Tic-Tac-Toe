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

        List<Player> players = new List<Player>();
        int turn = 0;
        Button[,] buttons = new Button[5,5];
        public GameForm()
        {
            InitializeComponent();
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateGame();
        }

        private void CreateGame()
        {
            foreach (Button b in buttons)
            {
                Controls.Remove(b);
            }
            players = GameBoard.CreateNewGame();
            if (players.Count != 0)
            {
                buttons = GameBoard.CreateBoard(this);
                foreach (Button b in buttons)
                {
                    b.Click += new EventHandler(button_Click);
                }
                label3.Text = "Player 1";
            }
        }

        private void ComputerPlayTurn()
        {
            Random rnd = new Random();
            List<Button> freeButtons = new List<Button>();
            foreach (Button b in buttons)
            {
                if (b.Text == "")
                {
                    freeButtons.Add(b);
                }
            }

            PlayTurn(freeButtons[rnd.Next(freeButtons.Count)]);
        }

        private void PlayTurn(Button button)
        {
            button.Text = players[turn].PlayerSymbol.ToString();
            button.Enabled = false;
            CheckGameOver();
            try
            {
                turn = (turn >= players.Count - 1) ? 0 : turn + 1;
                label3.Text = "Player " + (turn + 1).ToString();
                if (players[turn].PlayerType == Type.Computer)
                    ComputerPlayTurn();
            }
            catch { }
        }

        private void CheckGameOver()
        {
            if (GameBoard.CanWin(buttons, turn, players))
            {
                MessageBox.Show($"Player {players[turn].Name} won!", "Game Over");
                CreateGame();
            }else if (GameBoard.IsTie(buttons))
            {
                MessageBox.Show("Game resulted in a Tie", "Game Over");
                CreateGame();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            PlayTurn((Button) sender);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGame();
        }
    }
}
