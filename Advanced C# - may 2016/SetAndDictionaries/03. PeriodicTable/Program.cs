using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedSet<string> table = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                foreach (var token in tokens)
                {
                    table.Add(token);
                }
            }

            Console.WriteLine(string.Join(" ", table));
        }
    }
}
