using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2._3
{
    internal class Circle
    {
        public double Area { get; set; }
        public Circle(double area)
        {
            this.Area = area;

        }

        public static Circle operator +(Circle a, Circle b)
        {
            return new Circle(a.Area + b.Area);
        }

        public static Circle operator -(Circle a, Circle b)
        {
            return new Circle(a.Area - b.Area);
        }
    }
}
