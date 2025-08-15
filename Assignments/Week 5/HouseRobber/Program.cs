using System.Globalization;

namespace HouseRobber
{

    
    internal class Program
    {
        public static int Rob(int[] houses)
        {
            if (houses.Length == 0) // if array is empty
            {
                return 0;
            }
            if (houses.Length == 1) // if array has one element
            {
                return houses[0];
            }
            int maxTwoHousesAgo = houses[0]; // Robbing the first house
            int maxOneHouseAgo = Math.Max(houses[0], houses[1]); // Choose the best between robbing the first or second house

            for (int i = 2; i < houses.Length; i++)
            {
                // 2 7 3 1 9 10
                int robThis = houses[i] + maxTwoHousesAgo; // If we rob this house, we must skip the last house
                int skipThis = maxOneHouseAgo; // Or we can rob this one
                int currentMax = Math.Max(robThis, skipThis);

                //move to next iteration
                maxTwoHousesAgo = maxOneHouseAgo;
                maxOneHouseAgo = currentMax;
            }
            return maxOneHouseAgo;
        }
        static void Main(string[] args)
        {
            int[] houses = {10};
            int result = Rob(houses);
            Console.WriteLine($"Maximum you can rob: " + result);
                
        }
    }
}
