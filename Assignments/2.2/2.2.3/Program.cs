namespace _2._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---2.2.3---");
            Console.WriteLine("What shape do you have?\n" +
                "1. Circle\n" +
                "2. Square");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Circle circle = new Circle();
                    ShapePrompter.PromptForShapeInfo(circle);
                    Console.WriteLine("What's the radius of the circle?");
                    circle.Radius = Convert.ToDouble(Console.ReadLine());
                    circle.CalculateArea();
                    Console.WriteLine($"The circle's area is {circle.Area}");
                    break;
                case "2":
                    Square square = new Square();
                    ShapePrompter.PromptForShapeInfo(square);
                    Console.WriteLine("What's the length of a side?");
                    square.SideLength = Convert.ToDouble(Console.ReadLine());
                    square.CalculateArea();
                    Console.WriteLine($"The square's area is {square.Area}");
                    break;
                default:
                    Console.WriteLine("That's not a valid option.");
                    break;

            }
        }
    }
}
