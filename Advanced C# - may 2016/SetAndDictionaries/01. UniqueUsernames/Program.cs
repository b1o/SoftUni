using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();


            for (int i = 0; i < count; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
