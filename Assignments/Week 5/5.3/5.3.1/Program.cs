namespace _5._3._1
{
    using System;

    namespace FlowerbedAndStairs
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // ---------- Problem 1: Can Place Flowers ----------
                int[] flowerbed1 = { 1, 0, 0, 0, 1 };
                int n1 = 1;
                Console.WriteLine($"Input: [1,0,0,0,1], n=1 -> {CanPlaceFlowers((int[])flowerbed1.Clone(), n1)}");

                int[] flowerbed2 = { 1, 0, 0, 0, 1 };
                int n2 = 2;
                Console.WriteLine($"Input: [1,0,0,0,1], n=2 -> {CanPlaceFlowers((int[])flowerbed2.Clone(), n2)}");

                // ---------- Problem 2: Climbing Stairs ----------
                int steps1 = 2;
                Console.WriteLine($"Steps: 2 -> Ways: {ClimbStairs(steps1)}");

                int steps2 = 3;
                Console.WriteLine($"Steps: 3 -> Ways: {ClimbStairs(steps2)}");
            }

            public static bool CanPlaceFlowers(int[] flowerbed, int n)
            {
                if (n == 0) return true;

                for (int i = 0; i < flowerbed.Length; i++)
                {
                    if (flowerbed[i] == 0)
                    {
                        bool emptyLeft = (i == 0) || flowerbed[i - 1] == 0;
                        bool emptyRight = (i == flowerbed.Length - 1) || flowerbed[i + 1] == 0;

                        if (emptyLeft && emptyRight)
                        {
                            flowerbed[i] = 1; // plant here
                            n--;
                            if (n == 0) return true;
                        }
                    }
                }
                return n <= 0;
            }

            public static int ClimbStairs(int n)
            {
                if (n <= 2) return n;

                int a = 1; // ways to reach step 1
                int b = 2; // ways to reach step 2

                for (int i = 3; i <= n; i++)
                {
                    int c = a + b;
                    a = b;
                    b = c;
                }
                return b;
            }
        }
    }
}