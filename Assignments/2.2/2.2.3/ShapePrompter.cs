using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._3
{
    public class ShapePrompter
    {
        public static void PromptForShapeInfo(Shape shape)
        {
            string shapeType = shape.GetType().Name.ToLower();
            Console.WriteLine($"What is the {shapeType}'s name?");
            shape.ShapeName = Console.ReadLine();
            Console.WriteLine($"What is the {shapeType}'s ID?");
            shape.ShapeId = Console.ReadLine();
            Console.WriteLine($"What is the {shapeType}'s color?");
            shape.ShapeColor = Console.ReadLine();

        }
    }
}
