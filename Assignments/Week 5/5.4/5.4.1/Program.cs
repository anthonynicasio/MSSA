namespace _5._4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input any number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write($"The digits in the number {number} are: ");
            DisplayDigits(number);
            Console.WriteLine();
        }

        static void DisplayDigits(int num)
        {
            if (num == 0)
                return;

            DisplayDigits(num / 10); // Recursive call with the number excluding the last digit
            Console.Write(num % 10 + " "); // Print last digit after recursion
        }
    }
}
