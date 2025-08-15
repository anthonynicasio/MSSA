namespace Challenge_Lab_1
{
    internal class Program
    {
        static void Main()
        {
            // Problem 1: Single Number (every element appears twice except one)
            Console.WriteLine("Problem 1: Single Number");
            Console.WriteLine(SingleNumber(new[] { 2, 2, 1 }));           // 1
            Console.WriteLine(SingleNumber(new[] { 4, 1, 2, 1, 2 }));     // 4
            Console.WriteLine(SingleNumber(new[] { 1 }));                 // 1

            // Problem 2: Missing Number in range [0, n]
            Console.WriteLine("\nProblem 2: Missing Number");
            Console.WriteLine(MissingNumber(new[] { 3, 0, 1 }));                      // 2
            Console.WriteLine(MissingNumber(new[] { 0, 1 }));                         // 2
            Console.WriteLine(MissingNumber(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }));    // 8
        }
        static int SingleNumber(int[] nums)
        {
            int x = 0;
            foreach (var n in nums) x ^= n;
            return x;
        }

        static int MissingNumber(int[] nums)
        {
            long n = nums.Length;
            long expected = n * (n + 1) / 2;
            long actual = nums.Aggregate<int, long>(0, (acc, v) => acc + v);
            return (int)(expected - actual);
        }
    }
}
