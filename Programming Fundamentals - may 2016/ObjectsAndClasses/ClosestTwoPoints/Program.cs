using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestTwoPoints
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
            return $"({this.X}, {this.Y})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double closestDist = int.MaxValue;
            Point[] closestPoints = new Point[2];

            int numberOfPoints = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                points.Add(new Point(coords[0], coords[1]));
            }

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (j != i)
                    {
                        double dist = CalcDistance(points[i], points[j]);
                        if (dist < closestDist)
                        {
                            closestDist = dist;
                            closestPoints[0] = points[i];
                            closestPoints[1] = points[j];
                        }
                    }
                }
            }

            Console.WriteLine($"{closestDist}\r\n{closestPoints[0]}\r\n{closestPoints[1]}");
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
