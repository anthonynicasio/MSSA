namespace _4._3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Dictionary for Unique Ints
            Dictionary<int, int> uniqueInts = new();

            // Prompt for array length
            Console.Write("Input the number of elements to be stored in the array: ");
            if (!uint.TryParse(Console.ReadLine(), out uint arraySize))
            {
                Console.WriteLine("Enter a valid positive integer.");
            }

            // Create Array
            int[] userArray = new int[arraySize];
            int input;

            Console.WriteLine($"Input {arraySize} elements in the array:");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"element - {i}: ");
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Enter a valid integer.");
                    Console.Write($"element - {i}: ");
                }

                // Add unique array elemnts to dictionary

                if (uniqueInts.ContainsKey(input))
                {
                    uniqueInts[input]++;
                }
                else
                {
                    uniqueInts[input] = 1;
                }
            }

            Console.WriteLine("The unique elements in the array are:");
            bool found = false;
            foreach (var pair in uniqueInts)
            {
                if (pair.Value == 1)
                {
                    Console.WriteLine(pair.Key);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("None");
            }




        }
    }
}
