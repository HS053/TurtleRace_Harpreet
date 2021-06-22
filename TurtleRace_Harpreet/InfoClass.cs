using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleRace_Harpreet
{
    public class InfoClass
    {
        public static GuyClass GetBettorInfo(int ID)
        {
            switch (ID)
            {
                case 0:
                    return new Harpreet();

                case 1:
                    return new Sham();

                case 2:
                    return new Ram();
                default:
                    return new Harpreet();

            }
            //this initiates a new steve,dax or allan to hold the data from other classes.

        }
    }
}
