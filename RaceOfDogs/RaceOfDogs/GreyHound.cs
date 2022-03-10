using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RaceOfDogs
{
    class GreyHound
    {
        public int startingPosition;
        public int RaceLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;


        public bool Run()
        {
            Randomizer = new Random();
            int distance = Randomizer.Next(1, 3);
            MoveMyPictureBox(distance);
            Location += distance;
            if (Location >= (RaceLength - startingPosition))
            {
                return true;
            }

            return false;


        }



        public void TakeStartingPoint()
        {
            MoveMyPictureBox(-Location);
            Location = 0;
        }

        public void MoveMyPictureBox(int distance)
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }
    }

}
