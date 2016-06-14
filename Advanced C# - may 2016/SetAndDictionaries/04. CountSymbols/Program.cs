using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> set = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (set.ContainsKey(ch))
                {
                    set[ch]++;
                }
                else
                {
                    set.Add(ch, 1);
                }
            }

            foreach (var pair in set)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
