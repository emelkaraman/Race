using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceOfDogs
{
    class Bet
    {
        public int amount;
        public int dog;
        private Guys guy;

        public Bet(int amount, int dog, Guys guy)
        {
            this.amount = amount;
            this.dog = dog;
            this.guy = guy;
        }

        public string GetDescription()
        {
            string description = "";

            if (amount > 0)
            {
                description = String.Format("{0} bets {1} on dog #{2}", guy.Name, amount, dog);
            }
            else
            {
                description = String.Format("{0} hasn't placed a bet", guy.Name);
            }
            return description;
        }

        public int PayOut(int winner)
        {
            if (dog == winner)
            {
                return amount;
            }
            return -amount;
        }
    }

}
