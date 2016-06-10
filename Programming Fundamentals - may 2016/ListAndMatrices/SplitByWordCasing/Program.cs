using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input=
                Console.ReadLine()
                    .Split(new char[] {',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '/', '[', ']', ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowerCase = new List<string>();
            List<string> mied = new List<string>();
            List<string> upperCase = new List<string>();

            foreach (var word in input)
            {
                int check;
                if (int.TryParse(word, out check))
                {
                    mied.Add(word);
                }
                else if (word.ToLower() == word)
                {
                    lowerCase.Add(word);
                }
                else if (word.ToUpper() == word)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mied.Add(word);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mied)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }
    }
}
