using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[rnd.Next(0, words.Length)]);
            }
        }
    }
}
