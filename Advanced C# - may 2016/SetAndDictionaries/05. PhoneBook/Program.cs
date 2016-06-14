using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            string input = Console.ReadLine();

            
            while (input != "search")
            {
                string[] tokens = input.Split('-');
                string name = tokens[0];
                string number = tokens[1];
                if (phoneBook.ContainsKey(name))
                {
                    phoneBook[name] = number;
                }
                else
                {
                    phoneBook.Add(name, number);
                }
                        
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input.ToLower() != "stop")
            {
                string searchedName = input;
                if (phoneBook.ContainsKey(searchedName))
                {
                    Console.WriteLine($"{searchedName} -> {phoneBook[searchedName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchedName} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
