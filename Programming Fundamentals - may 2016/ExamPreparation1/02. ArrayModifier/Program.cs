using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split().Select(long.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                input = input.Trim();
                string[] commandTokens = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                int firstIndex = 0;
                int secondIndex= 0;

                switch (commandTokens[0].Trim())
                {
                    case "swap":
                        if (numbers.Count > 1)
                        {
                            firstIndex = int.Parse(commandTokens[1].Trim());
                            secondIndex = int.Parse(commandTokens[2].Trim());
                            Swap(firstIndex, secondIndex, numbers);
                        }
                        break;
                    case "multiply":
                        firstIndex = int.Parse(commandTokens[1].Trim());
                        secondIndex = int.Parse(commandTokens[2].Trim());
                        numbers[firstIndex] *= numbers[secondIndex];
                        break;
                    case "decrease":
                        numbers = numbers.Select(x => x -= 1).ToList();
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Swap(int firstIndex, int secondIndex, List<long> numbers)
        {
            long temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
