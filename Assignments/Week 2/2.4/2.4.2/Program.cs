using System.Text.Json.Nodes;

namespace _2._4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many elements are in your array?");
            bool isValidSize = int.TryParse(Console.ReadLine(), out int arraySize);

            if (!isValidSize || arraySize < 1)
            {
                Console.WriteLine("Invalid entry. Please enter a positive integer");
                return;
            }

            int[] testArray = new int[arraySize];

            for (int i = 0; i < testArray.Length; i++)
            {

                Console.WriteLine($"Input the number for element {i}: ");
                bool isValidElement = int.TryParse(Console.ReadLine(), out int element);

                if (!isValidElement)
                {
                    Console.WriteLine("Invalid entry. Please enter an integer.");
                }

                testArray[i] = element;
            }

            int largestValue = int.MinValue;
            int largestIndex = -1;

            for (int i = 0; i < testArray.Length; i++)
            {
                if (testArray[i] > largestValue)
                {
                    largestValue = testArray[i];
                    largestIndex = i;

                }
            }
            Console.WriteLine($"The {AddOrdinal.Ordinal(largestIndex + 1)} is the greatest among the {testArray.Length} values");
        }
    }
}
