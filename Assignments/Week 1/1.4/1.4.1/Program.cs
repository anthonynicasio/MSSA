namespace _1._4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point P1 = new Point();
            Point P2 = new Point();
            Console.Write("Enter the x coordinate for P1: ");
            P1.X = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the y coordinate for P1: ");
            P1.Y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the x coordinate for P2: ");
            P2.X = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the y coordinate for P2: ");
            P2.Y = Convert.ToDouble(Console.ReadLine());

            if (P2.X > P1.X)
            {
                Console.WriteLine("P2 is to the right of P1.");
            }
            else if (P2.X < P1.X)
            {
                Console.WriteLine("P2 is to the left of P1.");
            }
            else
            {
                Console.WriteLine("P2 is on the same vertical axis as P1.");
            }
        }
    }
}
