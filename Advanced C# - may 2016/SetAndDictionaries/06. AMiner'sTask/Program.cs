using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AMiner_sTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string name = input;
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(name))
                {
                    resources[name] += quantity;
                }
                else
                {
                    resources.Add(name, quantity);
                }

                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
