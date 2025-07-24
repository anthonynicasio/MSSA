using System.Globalization;

namespace _3._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(10);
            Circle circle2 = new Circle(5);
            
            Circle sumArea = circle1 + circle2;
            Circle differenceArea = circle1 - circle2;
            Console.WriteLine($"The sum of the areas are: {sumArea.Area}");
            Console.WriteLine($"The difference of the areas are: {differenceArea.Area}");

            
        }
    }
}
