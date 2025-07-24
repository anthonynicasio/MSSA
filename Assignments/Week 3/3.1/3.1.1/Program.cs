using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnEvenNumbers
{
    internal class ReturnEvenNumbers
    {
        // Problem 1: Return even numbers method
        public static string GetEvenNumbers()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 2; i <= 98; i += 2)
            {
                sb.Append(i);
                if (i < 98)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            // Test the method
            Console.WriteLine("Even numbers from 2 to 98:");
            Console.WriteLine(ReturnEvenNumbers.GetEvenNumbers());

            Console.ReadLine(); // Keep console open
        }
    }
}