namespace _3._1._4
{
    internal class Program
    {
        static void Main()
        {
            int[] inputArray = { 0, 2, 1, 1, 9, 1, 1 };
            ReplaceFirstConsecutiveOnes(ref inputArray);
            Console.WriteLine("Output: [" + string.Join(",", inputArray) + "]");
        }
        static void ReplaceFirstConsecutiveOnes(ref int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == 1 && array[i + 1] == 1)
                {
                    array[i] = 0;
                    array[i + 1] = 0;
                    break;
                }
            }
        }
    }
}
