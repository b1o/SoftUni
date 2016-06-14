using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string name = input;
                string email = Console.ReadLine();

                emails.Add(name, email);

                input = Console.ReadLine();
            }

            emails = emails.Where(x => !x.Value.Contains(".us") && !x.Value.Contains(".uk")).ToDictionary(x => x.Key, x => x.Value);

            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}
