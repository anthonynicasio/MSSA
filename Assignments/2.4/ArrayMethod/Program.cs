using System.Text.Json.Serialization.Metadata;

namespace ArrayMethod
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int arrayLength, startingValue, nthNumber
                ;
            Console.WriteLine("What is the length of your array?");
            if (!int.TryParse(Console.ReadLine(), out arrayLength) || arrayLength <= 0 || arrayLength > 1000)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer up to 1000.");
                return;
            }

            Console.WriteLine("What is the starting value?");
            if (!int.TryParse(Console.ReadLine(), out startingValue))
            {
                Console.WriteLine("Invalid input. Please enter an integer");
                return;
            }

            Console.WriteLine("The array will generate every nth number Enter 'n': ");
            if (!int.TryParse(Console.ReadLine(), out nthNumber) || nthNumber <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int[] userArray = GenerateNthArray(arrayLength, startingValue, nthNumber);

            Console.WriteLine("Generate Array:");
            foreach (int num in userArray)
            {
                Console.Write(num + " ");
            }

            static int[] GenerateNthArray(int length, int start, int step)
            {
                int[] result = new int[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = start + (i * step);
                }
                return result;
            }
        }
    }
}