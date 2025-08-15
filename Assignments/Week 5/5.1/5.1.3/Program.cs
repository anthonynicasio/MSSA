namespace _5._1._3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(ContainsDuplicate(new[] { 1, 2, 3, 1 }));                  // true
            Console.WriteLine(ContainsDuplicate(new[] { 1, 2, 3, 4 }));                  // false
            Console.WriteLine(ContainsDuplicate(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 })); // true
        }

        static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var num in nums)
            {
                if (seen.Contains(num))
                    return true; // Duplicate found
                seen.Add(num);
            }
            return false; // All distinct
        }
    }
}
