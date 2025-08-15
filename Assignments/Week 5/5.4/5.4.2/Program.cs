namespace _5._4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the size of the square matrix: ");
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            // Input elements
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nThe matrix is:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Calculate sum of right diagonal (top-right to bottom-left)
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, size - 1 - i];
            }

            Console.WriteLine($"\nAddition of the right Diagonal elements is: {sum}");
        }
    }
}
