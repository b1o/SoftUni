using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
    class Rectangle
    {
        public Rectangle(int left, int top, int width, int height)
        {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;

            this.Right = this.Left + this.Width;
            this.Bottom = this.Top + this.Height;
        }

        public int Bottom { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Left { get; set; }

        public int Right { get; set; }

        public int Top { get; private set; }

        public string IsInside(Rectangle r1)
        {
            if (this.Left >= r1.Left && this.Right <= r1.Right && this.Top <= r1.Top && this.Bottom <= r1.Bottom)
            {
                return "Inside";
            }
            else
            {
                return "Not Inside";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = ParseRect(Console.ReadLine());
            Rectangle rect2 = ParseRect(Console.ReadLine());

            Console.WriteLine(rect1.IsInside(rect2));
        }

        static Rectangle ParseRect(string input)
        {
            int[] tokens = input.Split(' ').Select(int.Parse).ToArray();

            return new Rectangle(tokens[0], tokens[1], tokens[2], tokens[3]);
        }
    }
}
