using System.ComponentModel;

namespace _2._4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 0;
            Console.Write($"Input the number of elements to be stored in the array: ");
            while (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            int[] userArray = new int[arraySize];
            Console.WriteLine($"Input {arraySize} elements in the array: ");

            int sum = 0;
            for (int i = 0; i < arraySize; i++)
            {
                int element = 0;
                Console.Write($"element - {i}: ");
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Invalid input. Please enter an integer");
                }
                userArray[i] = element;
                sum += element;
            }
            Console.WriteLine($"Sum of all elements stored in the array is: {sum}");
        }
    }
}
