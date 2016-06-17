using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();
            var stop = keyMaterials.FirstOrDefault(x => x.Value >= 250);

            string pattern = @"(\d+\s\w+)";

            while (stop.Key == null)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 1; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i - 1]);
                    string name = input[i].ToLower();

                    if (keyMaterials.ContainsKey(name))
                    {
                        keyMaterials[name] += quantity;
                        stop = keyMaterials.FirstOrDefault(x => x.Value >= 250);
                        if (stop.Key != null) break;
                    }
                    else
                    {
                        if (junk.ContainsKey(name))
                        {
                            junk[name] += quantity;
                        }
                        else
                        {
                            junk.Add(name, quantity);
                        }
                    }
                }

            }

            switch (stop.Key)
            {
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    keyMaterials["fragments"] -= 250;
                    break;
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    keyMaterials["shards"] -= 250;
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    keyMaterials["motes"] -= 250;
                    break;
            }
            foreach (var pair in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var i in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
            }
        }
    }
}
