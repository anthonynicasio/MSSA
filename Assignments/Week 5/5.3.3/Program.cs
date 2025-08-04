using System.Numerics;

namespace _5._3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the array");
            if (!uint.TryParse(Console.ReadLine(), out uint arrayLen))
            {
                Console.WriteLine("Enter a valid positive integer.");
            }

            int[] userArray = new int[arrayLen];
            int input;
            Dictionary<int, int> intFrequency = new Dictionary<int, int>();

            for (int i = 0; i < arrayLen; i++)
            {
                Console.Write($"Element - {i}: ");
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Enter a valid integer.");
                    Console.Write($"element - {i}: ");
                }

                if (intFrequency.ContainsKey(input))
                {
                    intFrequency[input]++;
                }
                else
                {
                    intFrequency[input] = 1;
                }

            }

            bool hasMultiple = false;
            foreach (var pair in intFrequency)
            {
                if (pair.Value == 1)
                {
                    Console.WriteLine($"{pair.Key} appears {pair.Value} time.");
                    hasMultiple = false;
                }
                else
                {
                    Console.WriteLine($"{pair.Key} appears {pair.Value} times.");
                    hasMultiple = true;
                }
            }
            Console.WriteLine(hasMultiple);


        }
    }
}