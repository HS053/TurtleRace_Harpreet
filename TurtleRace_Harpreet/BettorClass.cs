using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleRace_Harpreet
{
    // 3 classes, 1 for each bettor settor there cash amount, their names and setting labelmax from Guy class
    public class Harpreet : GuyClass
    {
        public Harpreet()
        {
            PlayerName = "Harpreet";
            Cash = 50;
            Labelmax.Text = Convert.ToString(Cash);
        }
    }

    public class Sham : GuyClass
    {
        public Sham()
        {
            PlayerName = "Sham";
            Cash = 50;
            Labelmax.Text = Convert.ToString(Cash);
        }
    }

    public class Ram : GuyClass
    {
        public Ram()
        {
            PlayerName = "Ram";
            Cash = 50;
            Labelmax.Text = Convert.ToString(Cash);
        }
    }
}
