namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testScores = { 50, 43, 79, 81, 93, 67 };
            sortTests(testScores);

            Console.WriteLine(string.Join(", ", testScores));

        }
        public static void sortTests(int[] testScores)
        {
            int min = 0, temp = 0;
            for (int i = 0; i < testScores.Length; i++)
            {
                min = testScores[i];
                for (int j = 0; j < testScores.Length; j++)
                {
                    if (testScores[i] < testScores[j])
                    {
                        temp = testScores[i];
                        testScores[i] = testScores[j];
                        testScores[j] = temp;
                    }


                }
            }
        }
    }
}
