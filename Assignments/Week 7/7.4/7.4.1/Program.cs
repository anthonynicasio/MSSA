using System.Numerics;

namespace _7._4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingSystem parkingSystem = new ParkingSystem(1, 1, 0);
            bool[] cars = new bool[4];

            cars[0] = parkingSystem.addCar(1);
            cars[1] = parkingSystem.addCar(2);
            cars[2] = parkingSystem.addCar(3);
            cars[3] = parkingSystem.addCar(1);
            
            foreach (bool b in cars)
            {
                Console.WriteLine(b);
            }
        }
    }
}
