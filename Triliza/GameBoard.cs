using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triliza
{
    class GameBoard
    {
        private const int BUTTON_HEIGHT = 70;
        private const int BUTTON_WIDTH = 70;

        private const int BOARD_WIDTH = 5;
        private const int BOARD_HEIGHT = 5;

        public static bool CanWin(Button[,] buttons, int turn, List<Player> players)
        {
            bool vertical = true;
            bool horizontal = true;
            bool diagonally = true;
            bool bdiagonally = true;
            for (int i = 0; i < BOARD_WIDTH; ++i)
            {
                for (int j = 0; j < BOARD_HEIGHT; ++j)
                {
                    if (buttons[i, j].Text != players[turn].PlayerSymbol.ToString())
                    {
                        vertical = false;
                    }
                    if (buttons[j, i].Text != players[turn].PlayerSymbol.ToString())
                    {
                        horizontal = false;
                    }

                }
                if (vertical || horizontal)
                {
                    return true;
                }
                vertical = true;
                horizontal = true;

                if (buttons[i, i].Text != players[turn].PlayerSymbol.ToString())
                {
                    diagonally = false;
                }
                if (buttons[BOARD_WIDTH-i-1,i].Text != players[turn].PlayerSymbol.ToString())
                {
                    bdiagonally = false;
                }
            }
            return diagonally || bdiagonally;
        }

        public static Button[,] CreateBoard(GameForm game)
        {
            Button[,] buttons = new Button[5, 5];
            for (int i = 0; i < BOARD_WIDTH; ++i)
            {
                for (int j = 0; j < BOARD_HEIGHT; ++j)
                {
                    Button button = new Button
                    {
                        Height = BUTTON_HEIGHT,
                        Width = BUTTON_WIDTH
                    };
                    button.Location = new Point(i * button.Width, j * button.Height+30);
                    game.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
            return buttons;
        }
        public static List<Player> CreateNewGame()
        {
            Options options = new Options();
            options.ShowDialog();
            return options.players;
        }
        
        public static bool IsTie(Button[,] buttons)
        {
            foreach(Button b in buttons)
            {
                if(b.Text == "")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
