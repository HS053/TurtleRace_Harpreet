using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleRace_Harpreet
{
    public partial class Form1 : Form
    {
        private readonly GuyClass[] currentPunter = new GuyClass[3];
        private readonly TurtleClass[] myTurtle = new TurtleClass[4];
        public int SelectedTurtleNumber;
        public Form1()
        {
            InitializeComponent();
        }

        private void TurtleRun() //Makes The Turtle Move
        {
            myTurtle[0] = new TurtleClass { Name = "Turtle 1", mypb = pictureBox1 };
            myTurtle[1] = new TurtleClass { Name = "Turtle 2", mypb = pictureBox2 };
            myTurtle[2] = new TurtleClass { Name = "Turtle 3", mypb = pictureBox3 };
            myTurtle[3] = new TurtleClass { Name = "Turtle 4", mypb = pictureBox4 };

            var myrnd = new Random();
            var End = false;


            while (End == false)
            {
                for (var i = 0; i < 4; i++)
                {
                    myTurtle[i].mypb.Top += myrnd.Next(4, 8);
                    if (myTurtle[i].mypb.Top > 250)
                    {
                        End = true;

                        for (var j = 0; j < currentPunter.Length; j++)
                        {
                            currentPunter[j].Collect(i + 1); // dending on which kayaker won, the winning bettor collects his/her money

                            if (currentPunter[j].Cash == 0)
                            {
                                currentPunter[j].MyLabel.Text = currentPunter[j].PlayerName + " Is BANKRUPT!";
                            }


                        }
                        RadioButton[] rbs = { rbHarpreet, rbSham, rbRam };
                        for (int x = 0; x < rbs.Length; x++)
                            if (rbs[x].Checked)
                            {
                                lblMaxBet.Text = currentPunter[x].Cash.ToString();
                                break;
                            }
                        MessageBox.Show(myTurtle[i].Name + " Won!"); // displays in a label which kayaker won
                        ResetTurtles();
                        break;
                    }
                }

                Application.DoEvents();
                Invalidate();
            }
        }

        private void ResetTurtles() // resets the turtles & bettors labels so they can keep betting
        {
            for (var i = 0; i < 4; i++)
            {
                myTurtle[i].mypb.Top = 60;
            }
            foreach (var guy in currentPunter)
                if (guy.Cash > 0)
                    guy.MyLabel.Text = guy.PlayerName + " Has Not Yet Placed A Bet!";
        }


        private void btnBet_Click(object sender, EventArgs e)
        {
            currentPunter[SelectedTurtleNumber].MyBet.Amount = Convert.ToInt16(numericUpDownBet.Value);
            currentPunter[SelectedTurtleNumber].MyBet.turtle = Convert.ToInt16(numericUpDownTurtle.Value);


            for (int i = 0; i < currentPunter.Length; i++)
            {
                if (currentPunter[i].Cash == 0) continue;
                currentPunter[i].MyLabel.Text = currentPunter[i].PlayerName + " Bet $" + currentPunter[i].MyBet.Amount + " On Turtle " + currentPunter[i].MyBet.turtle;
            }

            btnRace.Enabled = true;
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            TurtleRun(); // makes the turtle move from this method when button is clicked
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRace.Enabled = false;
            for (int i = 0; i < currentPunter.Length; i++)
            {
                currentPunter[i] = InfoClass.GetBettorInfo(i);
            }
            currentPunter[0].MyLabel = lblHarpreetResult;
            currentPunter[1].MyLabel = lblShamResult;
            currentPunter[2].MyLabel = lblRamResult;
            // generates new bettors each time to store data & idenifies which label belongs to which bettor
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;

            if (rb.Checked)
            {
                switch (rb.Text)

                {
                    case "Harpreet":
                        SelectedTurtleNumber = 0;
                        lblMaxBet.Text = currentPunter[0].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[0].Labelmax.Text);
                        break;
                    case "Sham":
                        SelectedTurtleNumber = 1;
                        lblMaxBet.Text = currentPunter[1].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[1].Labelmax.Text);
                        break;
                    case "Ram":
                        SelectedTurtleNumber = 2;
                        lblMaxBet.Text = currentPunter[2].Labelmax.Text;
                        numericUpDownBet.Maximum = Convert.ToDecimal(currentPunter[2].Labelmax.Text);
                        break;
                }


                if (Convert.ToInt16(lblMaxBet.Text) == 0) // if a player has no money there label shows they are bankrupt
                {
                    rb.Enabled = false;

                }
            }
        }
    }
}
