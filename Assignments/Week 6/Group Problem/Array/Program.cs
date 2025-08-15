using System.ComponentModel;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] ints = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 9, 10 } };
            int arrayRows = 2;
            int arrayColumns = 5;
            if (arrayColumns * arrayRows == ints.Length)
            {
                int[,] ints2 = new int[arrayRows, arrayColumns];
                int counter = 0;
                for (int i = 0; i < ints.GetLength(0); i++)
                {
                    for (int j = 0; j < ints.GetLength(1); j++)
                    {
                        ints2[(counter / arrayColumns), (counter % arrayColumns)] = ints[i, j];
                        counter++;
                    }
                   
                }
                for (int i = 0; i < ints2.GetLength(0); i++)
                {
                    for (int i2 = 0; i2 < ints2.GetLength(1); i2++)
                    {
                        Console.Write(ints2[i, i2]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}