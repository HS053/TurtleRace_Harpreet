using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleRace_Harpreet
{
    public class GuyClass
    {
        public Label MyLabel = new Label(); // update bet result labels
        public Label Labelmax = new Label(); // sets each persons max bet

        public string PlayerName { get; set; }
        public BetClass MyBet = new BetClass();
        public int Cash { get; set; }



        public void Collect(int Winner) // get mybet to payout, clear the bet and update maxbet label
        {
            if (MyBet != null)
                Cash += Payout(Winner);
            Labelmax.Text = Cash.ToString();
        }

        public int Payout(int Winner) // How much money to payout
        {
            if (MyBet.turtle == Winner)
                return MyBet.Amount; // return the amount bet
            return -MyBet.Amount; // return the negitave of amount bet 
        }
    }
}
