namespace _2._4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quadrant q = new Quadrant();

            Console.WriteLine($"Input the value for X coordinate: ");
            if (!double.TryParse(Console.ReadLine(), out double xCoordinate))
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }

            Console.WriteLine($"Input the value for Y coordinate: ");
            if (!double.TryParse(Console.ReadLine(), out double yCoordinate))
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }

            q.QuadrantCalculator(xCoordinate, yCoordinate);
            Console.WriteLine($"The coordinate point ({xCoordinate}, {yCoordinate}) lies in the {q.QuadrantLocation} quadrant.");
        }
    }
}
