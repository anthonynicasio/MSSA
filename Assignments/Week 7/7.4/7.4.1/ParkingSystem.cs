using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._1
{
    public class ParkingSystem
    {
        public int Big { get; private set; }
        public int Medium { get; private set; }
        public int Small { get; private set; }

        public ParkingSystem(int big, int medium, int small)
        {
            Big = big;
            Medium = medium;
            Small = small;
        }

        public bool addCar(int carType)
        {
            // big = 1, medium = 2, small = 3
            switch (carType)
            {
                case 1: if (Big > 0) { Big--; return true; } return false;
                case 2: if (Medium > 0) { Medium--; return true; } return false;
                case 3: if (Small > 0) { Small--; return true; } return false;
                default: return false;
            }
        }
    }
}
