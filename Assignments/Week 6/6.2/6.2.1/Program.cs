namespace _6._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Stack Demo ---
            Console.WriteLine("Custom Stack Demo:");
            CustomStack stack = new CustomStack(5);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("Top element: " + stack.Peek());
            Console.WriteLine("Popped element: " + stack.Pop());
            Console.WriteLine("Top element after pop: " + stack.Peek());

            Console.WriteLine();

            // --- Product Except Self Demo ---
            Console.WriteLine("Product of Array Except Self:");
            int[] nums = { 1, 2, 3, 4 };
            int[] result = ProductExceptSelf(nums);
            Console.WriteLine(string.Join(", ", result));

            int[] nums2 = { -1, 1, 0, -3, 3 };
            int[] result2 = ProductExceptSelf(nums2);
            Console.WriteLine(string.Join(", ", result2));
        }

        // Product of Array Except Self
        public static int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            // Step 1: prefix products
            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            // Step 2: suffix products
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }

            return result;
        }
    }

}
