using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello";
            string s2 = "World";
            object concat = s1 + " " + s2;
            string print = (string) concat;

            Console.WriteLine(print);
        }
    }
}
