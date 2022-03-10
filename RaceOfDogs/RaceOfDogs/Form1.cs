using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceOfDogs
{
    public partial class Form1 : Form
    {
        GreyHound[] dogs = new GreyHound[4];
        Guys[] guys = new Guys[3];

        public Form1()
        {
            InitializeComponent();
            SetupRace();
        }

        private void SetupRace()
        {
            label4.Text = string.Format("Minimum bet {0:c}", (int)numericUpDown1.Minimum);

            int startingPosition = Pembe.Right - pictureBox1.Left;
            int raceTrackLength = pictureBox1.Size.Width;

            dogs[0] = new GreyHound()
            {
                MyPictureBox = Pembe,
                RaceLength = raceTrackLength,
                startingPosition = startingPosition
            };
            dogs[1] = new GreyHound()
            {
                MyPictureBox = Yumoş,
                RaceLength = raceTrackLength,
                startingPosition = startingPosition
            };
            dogs[2] = new GreyHound()
            {
                MyPictureBox = Ponçik,
                RaceLength = raceTrackLength,
                startingPosition = startingPosition
            };
            dogs[3] = new GreyHound()
            {
                MyPictureBox = Minnoş,
                RaceLength = raceTrackLength,
                startingPosition = startingPosition
            };

            guys[0] = new Guys("Joe", null, 50, Joe, label6);
            guys[1] = new Guys("Bob", null, 75, Bob, label7);
            guys[2] = new Guys("Al", null, 45, Al, label8);

            foreach (Guys guy in guys)
            {
                guy.UpdateLabels();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningDog;
            Bet.Enabled = false;//Yarış başladığında tekrardan bahis oynanamaması için.


            while (NoWinner)
            {
                Application.DoEvents();
                for (int i = 0; i < dogs.Length; i++)
                {
                    if (dogs[i].Run())
                    {
                        winningDog =i+1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner dog # " + winningDog );
                        foreach (Guys guy in guys)
                        {
                            if (guy.MyBet != null)
                            {
                                guy.Collect(winningDog);
                                guy.MyBet = null;
                                guy.UpdateLabels();
                            }
                        }
                        foreach (GreyHound dog in dogs)
                        {
                            dog.TakeStartingPoint();
                        }
                        break;
                    }
                }
            }
            Bet.Enabled = true;//Yarış bitince bahisler tekrar yapılabilir.
        }

        private void SetBettorNameTextLabel(string Name)
        {
            label5.Text = Name;
        }


        private void Joe_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Joe");
        }

        private void Bob_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Bob");
        }

        private void Al_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Al");
        }

        private void Bet_Click(object sender, EventArgs e)
        {
            int GuyNumber = 0;

            if (Joe.Checked)
            {
                GuyNumber = 0;
                if (numericUpDown1.Value > 50)
                {
                    MessageBox.Show("Joe doesn't have enough money!!");
                }
                else
                    MessageBox.Show("Accepted!!");
            }
            if (Bob.Checked)
            {
                GuyNumber = 1;
                if (numericUpDown1.Value > 75)
                {
                    MessageBox.Show("Bob doesn't have enough money!!");
                }
                else
                    MessageBox.Show("Accepted!!");
            }
            if (Al.Checked)
            {
                GuyNumber = 2;
                if (numericUpDown1.Value > 45)
                {
                    MessageBox.Show("Al doesn't have enough money!!");
                }
                else
                    MessageBox.Show("Accepted!!");
            }
            /* if komutlarında isimler hem guy dizisine atanıyor hem de kişilerin parası yetersizse ekrana olmayacağına dair 
            mesaj çıkıyor ,yeterliyse de kabul edildiğine dair mesaj çıkıyor.*/

            guys[GuyNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            guys[GuyNumber].UpdateLabels();

            
        }
    }
}
