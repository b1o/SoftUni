using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenPoints
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

        public override string ToString()
        {
            return $"X = {this.X} / Y = {this.Y}";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int[] coords1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point point1 = new Point(coords1[0], coords1[1]);

            int[] coords2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point point2 = new Point(coords2[0], coords2[1]);

            Console.WriteLine(CalcDistance(point1, point2));
        }

        static double CalcDistance(Point p1, Point p2)
        {
            int a = p1.X - p2.X;
            int b = p1.Y - p2.Y;

            double c = (Math.Pow(a, 2) + Math.Pow(b, 2));
            c = Math.Sqrt(c);
            return c;
        }
    }
}
