using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._3
{
    // Abstract class
    public abstract class Shape
    {
        public string ShapeId { get; set; }
        public string ShapeName { get; set; }
        public string ShapeColor { get; set; }
        public double Area { get; set; }
        public abstract void CalculateArea();

    }
    // Derived class (inherit from Shape)
    class Circle : Shape
    {
        public double Radius { get; set; }
        public override void CalculateArea()
        {
            Area = Math.PI * Math.Pow(Radius, 2);

        }
    }

    class Square : Shape
    {
        public double SideLength { get; set; }
        public override void CalculateArea()
        {
            Area = Math.Pow(SideLength, 2);
        }
    }

}