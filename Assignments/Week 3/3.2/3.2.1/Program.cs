namespace _3._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {2, 3, 4 },
                {1, 4, 6 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"| {matrix[i, j]} ");
                }
                Console.WriteLine("|");
            }
        }
    }
}