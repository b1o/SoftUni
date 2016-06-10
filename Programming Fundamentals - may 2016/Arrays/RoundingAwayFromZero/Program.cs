using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] input = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            foreach (var num in input)
            {
                Console.WriteLine($"{num} => {Math.Round(num, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
