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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = (radioButton1.Checked)? false: true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameForm.players.Add(new Player(textBox1.Text, Symbol.O, Type.Human));
            if (radioButton1.Checked)
            {
                GameForm.players.Add(new Player(textBox2.Text, Symbol.X, Type.Human));
            }
            else
            {
                GameForm.players.Add(new Player("Computer", Symbol.X, Type.Computer));
            }
            GameForm gameForm = new GameForm();
            gameForm.Show();
            Close();
        }
    }
}
