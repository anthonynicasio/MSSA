using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _6._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> list = new LinkedList<string>(words);
            Display(list, "The linked list values:");

        }
    
        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}