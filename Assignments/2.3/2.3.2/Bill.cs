using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._2
{
    internal class Bill
    {
        public Bill()
        {
            // Read bill amount
            Console.Write("Enter the bill total: ");
            if (!double.TryParse(Console.ReadLine(), out double bill) || bill < 0)
            {
                Console.WriteLine("Invalid bill amount.");
                return;
            }

            // Read tip percentage
            Console.Write("Enter the tip percentage (e.g., 18 for 18%): ");
            if (!double.TryParse(Console.ReadLine(), out double tipPercent) || tipPercent < 0)
            {
                Console.WriteLine("Invalid tip percentage.");
                return;
            }

            // Convert to a fraction, calculate
            double tipRate = tipPercent / 100.0;
            double tipAmount = bill * tipRate;
            double grandTotal = bill + tipAmount;

            // Display with format specifiers
            Console.WriteLine();
            Console.WriteLine($"Bill:        {bill,10:C}");                  // "C" → currency
            Console.WriteLine($"Tip ({tipRate:P0}): {tipAmount,10:C}");       // "P0" → percent, no decimals
            Console.WriteLine($"Grand Total: {grandTotal,10:C}");
        }

    }
}
