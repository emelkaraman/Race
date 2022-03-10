using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceOfDogs
{
    class Guys
    {
        public string Name;
        public Bet MyBet;
        public int MyCash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guys(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.MyCash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }

        public void UpdateLabels()
        {
            if (MyBet == null)
            {
                MyLabel.Text = String.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = Name + " has " + MyCash + " bucks";
        }

        public void ClearBet()
        {
            MyBet.amount = 0;
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            if (Amount <= MyCash)
            {
                MyBet = new Bet(Amount, Dog, this);
                return true;
            }
            return false;
        }

        public void Collect(int winner)
        {
            MyCash += MyBet.PayOut(winner);
        }




    }

}
