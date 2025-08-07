namespace TargetAddition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of your array:");
            if (!int.TryParse(Console.ReadLine(), out int userArrayLength) || userArrayLength <= 1)
            {
                Console.WriteLine("Invalid input. Enter an integer greater than 1.");
                return;
            }

            int[] nums = new int[userArrayLength];

            for (int i = 0; i < userArrayLength; i++)
            {
                Console.WriteLine($"Enter value #{i + 1}:");
                while (!int.TryParse(Console.ReadLine(), out nums[i]))
                {
                    Console.WriteLine("Invalid input. Enter an integer:");
                }
            }

            Console.WriteLine("What is the target sum?");
            if (!int.TryParse(Console.ReadLine(), out int targetNum))
            {
                Console.WriteLine("Invalid target. Must be an integer.");
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == targetNum)
                    {
                        Console.WriteLine($"Indices {i} and {j} (values {nums[i]} + {nums[j]}) add up to {targetNum}.");
                        return; // exit after first valid pair
                    }
                }
            }

            Console.WriteLine("No two numbers add up to the target.");
        }
    }
}
