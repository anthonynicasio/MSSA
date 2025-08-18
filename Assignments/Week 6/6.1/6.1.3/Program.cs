namespace _6._1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 0, 3, 12 };
            MoveZeroes(nums);
            Console.WriteLine(string.Join(", ", nums)); // Properly prints the array
        }

        public static void MoveZeroes(int[] nums)
        {
            int insertPos = 0;

            // Step 1: Move all non-zero elements forward
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[insertPos] = nums[i];
                    insertPos++;
                }
            }

            // Step 2: Fill the rest with zeros
            while (insertPos < nums.Length)
            {
                nums[insertPos] = 0;
                insertPos++;
            }
        }
    }
}
