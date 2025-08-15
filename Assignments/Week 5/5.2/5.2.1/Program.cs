namespace _5._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "The fox jumped over the hen  ";
            LastWord(sentence);
        }

    public static void LastWord(String s)
        {
            char[] separators = new char[] { ' ', ',' };

            string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string lastWord = subs[subs.Length - 1];

            Console.WriteLine($"Output:{lastWord.Length}");
            Console.WriteLine($"Explanation: The last word is {lastWord} with length {lastWord.Length}");
        }
    }
}