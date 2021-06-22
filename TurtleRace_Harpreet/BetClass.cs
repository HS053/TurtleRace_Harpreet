using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleRace_Harpreet
{
    public class BetClass
    {
        public int Amount { get; set; } // The Amont Of Money that was Bet
        public GuyClass Bettor; // The Person Who Placed The Bet
        public int turtle { get; set; } // Which turtle got bet on (1-4)
    }
}
