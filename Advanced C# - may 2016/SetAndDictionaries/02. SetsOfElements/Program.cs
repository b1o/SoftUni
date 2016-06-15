using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputTokens[0];
            int m = inputTokens[1];

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                set1.Add(Int32.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            set1.IntersectWith(set2);

            Console.WriteLine(string.Join(" ", set1));
        }
    }
}
