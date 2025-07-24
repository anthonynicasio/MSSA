namespace _3._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j;

            Console.Write("Input the size of the square matrix (less than 5): ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] sumMatrix = new int[n, n];

            Console.WriteLine("\nInput elements in the first matrix:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("\nInput elements in the second matrix:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Calculating the sum of the two matrices
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            // Displaying the matrices
            Console.WriteLine("\nThe First matrix is:");
            PrintMatrix(matrix1, n);

            Console.WriteLine("\nThe Second matrix is:");
            PrintMatrix(matrix2, n);

            Console.WriteLine("\nThe Addition of two matrix is:");
            PrintMatrix(sumMatrix, n);
        }

        static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}