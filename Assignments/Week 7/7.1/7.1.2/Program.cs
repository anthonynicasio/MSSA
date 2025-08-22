namespace _7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word 1: ");
            string? word1 = Console.ReadLine();
            Console.Write("Enter word 2: ");
            string? word2 = Console.ReadLine();

            Console.WriteLine(WordAppender(word1 ?? "", word2 ?? ""));
        }


        public static string WordAppender(string? word1, string? word2)
        {
            string output = "";
            int minLength = Math.Min(word1.Length, word2.Length);

            // Interweave common length
            for (int i = 0; i < minLength; i++)
                {
                    output += $"{word1[i]}{word2[i]}";
                }
            // Append the remaining part of the longer word
            if (word1.Length > word2.Length)
            {
                output += word1.Substring(minLength);
            }
            else if (word2.Length > word1.Length)
            {
                output += word2.Substring(minLength);
            }
                return output;
        }
    }
}
