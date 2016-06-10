using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMinMaxFirstLastAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"Sum = {numbers.Sum()}\r\nMin = {numbers.Min()}\r\nMax = {numbers.Max()}\r\nFirst = {numbers.First()}\r\nLast = {numbers.Last()}\r\nAverage = {numbers.Average()}");
        }
    }
}
