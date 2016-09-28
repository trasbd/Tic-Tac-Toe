using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Form
{
    public partial class Form1 : Form
    {
        bool turn = true; //True is X False is O
        String xSymbol = Properties.Settings.Default.player1;

        String oSymbol = Properties.Settings.Default.player2;
        Button[] buttonArray;
        const int NUM_BUTTONS = 9;
        
        
        public Form1()
        {
            InitializeComponent();
            buttonArray = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }

        

        private void btn1_Click(object sender, EventArgs e)
        {
            clicked(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            clicked(btn2);
        }

        private void clicked(Button btn)
        {
            if (btn.Text == " ")
            {
                if (turn)
                    btn.Text = xSymbol;
                else
                    btn.Text = oSymbol;
                turn = !turn;
                update();
            }
        }

        private void update()
        {
            char winner = winnerCheck();
            if (winner == 'n')
            {
                if (turn)
                    lblturn.Text = xSymbol + " Turn";
                else
                    lblturn.Text = oSymbol + " Turn";
            }
            else if (winner == 'c')
            {
                lblturn.Text = "Cat's game!";
                btnAgain.Visible = true;
            }
            else
            {
                lblturn.Text = winner + " is the Winner!";

                //Disables all grid buttons
                for (int i = 0; i < NUM_BUTTONS; i++ )
                {
                    buttonArray[i].Enabled = false;
                }
                btnAgain.Visible = true;


            }
        }

        private char winnerCheck()
        {
            char winnerFound = 'n';
            char[,] grid = new char[3, 3];
            grid[0, 0] = btn1.Text[0];
            grid[0, 1] = btn2.Text[0];
            grid[0, 2] = btn3.Text[0];
            grid[1, 0] = btn4.Text[0];
            grid[1, 1] = btn5.Text[0];
            grid[1, 2] = btn6.Text[0];
            grid[2, 0] = btn7.Text[0];
            grid[2, 1] = btn8.Text[0];
            grid[2, 2] = btn9.Text[0];

            //Checking rows and cols for 3 in row
            for (int i = 0; i < 3; i++ )
            {
                if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2] && grid[i,0]!= ' ')
                    winnerFound = grid[i, 0];
                else if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i] && grid[0, i] != ' ')
                    winnerFound = grid[0, i];
            }
            //checking diagonals
            if (winnerFound == 'n')
            {
                if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && grid[0, 0] != ' ')
                    winnerFound = grid[0, 0];
                else if (grid[2, 0] == grid[1, 1] && grid[1, 1] == grid[0, 2] && grid[1, 1] != ' ')
                    winnerFound = grid[0, 2];
            }

            //Check for cats game
            if (winnerFound == 'n')
            {
                winnerFound = 'c';
                for (int i =0; i < NUM_BUTTONS; i++)
                {
                    if (buttonArray[i].Text[0] == ' ')
                        winnerFound = 'n';
                }
            }

                return winnerFound;
        }


        private void btn3_Click(object sender, EventArgs e)
        {
            clicked(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            clicked(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            clicked(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            clicked(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            clicked(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            clicked(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            clicked(btn9);
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            xSymbol = Properties.Settings.Default.player1;
            oSymbol = Properties.Settings.Default.player2;
            for (int i = 0; i < NUM_BUTTONS; i++)
            {
                buttonArray[i].Enabled = true;
                buttonArray[i].Text = " ";
            }
            lblturn.Text = xSymbol + " Turn";
            turn = true;
            btnAgain.Visible = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options frm = new Options();
            frm.Show();

        }



    }
}
