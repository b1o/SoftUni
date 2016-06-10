using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
    class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public static Circle Parse(string input)
        {
            string[] tokens = input.Split(' ');
            Point center = new Point(int.Parse(tokens[0]), int.Parse(tokens[1]));

            return new Circle(center, int.Parse(tokens[2]));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = Circle.Parse(Console.ReadLine());
            Circle circle2 = Circle.Parse(Console.ReadLine());

            if (Intersects(circle1, circle2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static bool Intersects(Circle c1, Circle c2)
        {
            double a = c1.Center.X - c2.Center.X;
            double b = c1.Center.Y - c2.Center.Y;
            double distance = Math.Sqrt((a*a) + (b*b));

            if (distance <= c1.Radius + c2.Radius)
            {
                return true;
            }

            return false;
        }
    }
}
