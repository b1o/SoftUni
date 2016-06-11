using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftuniCoffeeSupplies
{
    class Person
    {
        public string Name { get; set; }
        public string CoffeeType { get; set; }

        public Person(string name, string coffeeType)
        {
            this.Name = name;
            this.CoffeeType = coffeeType;
        }
    }

    class CoffeeStorage
    {
        public Dictionary<string, int> storage { get; set; }

        public CoffeeStorage()
        {
            storage = new Dictionary<string, int>();
        }

        public bool getCoffee(string name, int amount)
        {
            if (storage.ContainsKey(name))
            {
                if (storage[name] - amount >= 0)
                {
                    storage[name] -= amount;
                    return true;
                }
            }
            return false;
        }

        public string Report(out List<string> coffeeLeft)
        {
            StringBuilder result = new StringBuilder();
            coffeeLeft = new List<string>();

            foreach (var pair in storage)
            {
                if (pair.Value <= 0)
                {
                    result.Append($"Out of {pair.Key}\r\n");
                }
            }
            result.Append("Coffee Left:\r\n");
            foreach (var pair in storage.OrderByDescending(x => x.Value))
            {
                if (pair.Value > 0)
                {
                    result.Append($"{pair.Key} {pair.Value}\r\n");
                    coffeeLeft.Add(pair.Key);
                }
            }

            return result.ToString().Trim();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] separatorTokens = Console.ReadLine().Split();
            string personSeparator = separatorTokens[0];
            string coffeeSeparator = separatorTokens[1];

            List<Person> people = new List<Person>();
            CoffeeStorage storage = new CoffeeStorage();

            string input = Console.ReadLine();

            while (input != "end of info")
            {
                if (input.Contains(personSeparator))
                {
                    string[] tokens = input.Split(new string[] {personSeparator}, StringSplitOptions.None);
                    string personName = tokens[0];
                    string coffeeName = tokens[1];

                    Person person = new Person(personName, coffeeName);
                    people.Add(person);

                    if (!storage.storage.ContainsKey(coffeeName))
                    {
                        storage.storage.Add(coffeeName, 0);
                    }
                }
                else if (input.Contains(coffeeSeparator))
                {
                    string[] tokens = input.Split(new string[] {coffeeSeparator}, StringSplitOptions.None);
                    string coffeeName = tokens[0];
                    int coffeeAmount = int.Parse(tokens[1]);

                    if (storage.storage.ContainsKey(coffeeName))
                    {
                        storage.storage[coffeeName] += coffeeAmount;
                    }
                    else
                    {
                        storage.storage.Add(coffeeName, coffeeAmount);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of week")
            {
                

                string[] inputTokens = input.Split();
                string name = inputTokens[0];
                int amount = int.Parse(inputTokens[1]);

                string coffeeType = people.Find(x => x.Name == name).CoffeeType;
                bool hasCoffe = storage.getCoffee(coffeeType, amount);

                input = Console.ReadLine();
            }

            List<string> coffeLeft;
            Console.WriteLine(storage.Report(out coffeLeft));
            Console.WriteLine("For:");

            foreach (var person in people.OrderBy(x => x.CoffeeType).ThenByDescending(x => x.Name).ToList())
            {
                if (coffeLeft.Contains(person.CoffeeType))
                {
                    Console.WriteLine($"{person.Name} {person.CoffeeType}");
                }
            }
        }

        
    }
}
