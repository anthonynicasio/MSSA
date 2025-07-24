namespace _2._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user input
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();

            Console.WriteLine("What is your age?");
            string userAge = Console.ReadLine();

            Console.WriteLine("What is your address?");
            string userAddress = Console.ReadLine();

            // Set the full file path (not just relative)
            string docPath = @"C:\Users\notto\source\repos\MSSA\Assignments\2.3\2.3.1";
            string filePath = Path.Combine(docPath, "WriteLines.txt");

            // Make sure the directory exists
            Directory.CreateDirectory(docPath);

            // Add labels to each line
            string[] lines = {
                $"Name: {userName}",
                $"Age: {userAge}",
                $"Address: {userAddress}"
            };

            // Write the labeled info to the file
            File.WriteAllLines(filePath, lines);

            // Read the file from the same path you wrote to
            try
            {
                using StreamReader reader = new(filePath);
                string text = reader.ReadToEnd();
                Console.WriteLine("\n--- File Contents ---");
                Console.WriteLine(text);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
