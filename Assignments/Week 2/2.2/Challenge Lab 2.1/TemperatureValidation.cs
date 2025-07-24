using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Lab_2._1
{
    internal class TemperatureValidation
    {
        public static int ReadValidTemperature()
        {
            while (true)
            {
                Console.Write("Enter temperature in Fahrenheit: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int temperature))
                {
                    return temperature;
                }
                Console.WriteLine("Invalid input. Please enter a whole number");

            }
        }

    }
}
