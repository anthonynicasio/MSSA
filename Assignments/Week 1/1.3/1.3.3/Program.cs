namespace _1._3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"How many elements are in your array?");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            int[] userArray = new int[arraySize];

            Console.WriteLine($"Input the {arraySize} elements in your array:");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"Element - {i}: ");
                userArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("The values stored in your array are: ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine(userArray[i]);
            }

            Console.WriteLine("The values stored in reverse order are:");
            for(int i = arraySize - 1;i >= 0; i--)
            {
                Console.WriteLine(userArray[i]);
            }
        }
    }
}