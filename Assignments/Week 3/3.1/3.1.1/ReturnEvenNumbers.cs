using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._1
{
    internal class ReturnEvenNumbers
    {
        // Problem 1: Return even numbers method
        public static string GetEvenNumbers()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 2; i <= 98; i += 2)
            {
                sb.Append(i);
                if (i < 98)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}