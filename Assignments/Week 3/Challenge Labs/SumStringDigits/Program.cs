namespace SumStringDigits
{
    internal class Program
    {
        static int SumDigitsInString(string input)
        {
            int result = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    result += int.Parse($"{c}");
                }

            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string:");
            string? userInput = Console.ReadLine();
            Console.WriteLine(SumDigitsInString(userInput));
        }
    }
}

