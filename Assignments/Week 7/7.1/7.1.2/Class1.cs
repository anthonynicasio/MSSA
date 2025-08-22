using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    internal class Class1
    {
        public static string MergeStringsAlternating(string word1, string word2)
        {
            int word1Pointer = 0;
            int word2Pointer = 0;
            StringBuilder answer = new StringBuilder();
            while (word1Pointer < word1.Length || word2Pointer < word2.Length)
            {
                if (word1Pointer < word1.Length)
                {
                    answer.Append(word1[word1Pointer]);
                    word1Pointer++;
                }
                if (word2Pointer < word2.Length)
                {
                    answer.Append(word2[word2Pointer]);
                    word2Pointer++;
                }
            }
            return answer.ToString();
        }
    }
}
