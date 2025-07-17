namespace _2._3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the bill total: ");
            if (!double.TryParse(Console.ReadLine(), out double bill) || bill < 0)
            {
                Console.WriteLine("Invalid bill amount.");
                return;
            }
            Console.Write("Enter the tip percentage (ex: 18 for 18%): ");
            if (!double.TryParse(Console.ReadLine(), out double tipPercent) || tipPercent < 0)
            {
                Console.WriteLine("Invalid tip percentage.");
                return;
            }
            double tipRate = tipPercent / 100.0;
            double tipAmount = bill * tipRate;
            double grandTotal = bill + tipAmount;
            Console.WriteLine();
            Console.WriteLine($"Bill:        {bill,10:C}");                  // "C" = currency
            Console.WriteLine($"Tip ({tipRate:P0}):   {tipAmount,10:C}");       // "P0" = percent, no decimals
            Console.WriteLine($"Grand Total: {grandTotal,10:C}");
        }
    }
}
