using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4._3
{
    internal class Quadrant
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string QuadrantLocation { get; set; }


        public void QuadrantCalculator(double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            if (XCoordinate > 0 && YCoordinate > 0)
            {
                QuadrantLocation = "first";
            }
            else if (XCoordinate < 0 && YCoordinate > 0)
            {
                QuadrantLocation = "second";
            }
            else if (XCoordinate < 0 && YCoordinate < 0)
            {
                QuadrantLocation = "third";
            }
            else if (XCoordinate > 0 && YCoordinate < 0)
            {
                QuadrantLocation = "fourth";
            }
            else
            {
                QuadrantLocation = "on an axis";
            }
        }
    }
}
