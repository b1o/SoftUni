using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    class User {
        public string Username { get; set; }
        public Dictionary<string, int> IPS { get; set; }
        public List<string> Messages { get; set; }

        public User(string username)
        {
            this.Username = username;
            this.IPS = new Dictionary<string, int>();
            this.Messages = new List<string>();
        }

        public string PrintIPs()
        {
            StringBuilder result = new StringBuilder();

            foreach (var i in IPS)
            {
                result.Append($"{i.Key} => {i.Value}, ");
            }
            result[result.Length - 2] = '.';
            return result.ToString().Trim();
        }

        public void AddIp(string ip)
        {
            if (this.IPS.ContainsKey(ip))
            {
                this.IPS[ip]++;
            }
            else
            {
                this.IPS.Add(ip, 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Test in judge

            List<User> users = new List<User>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split();
                var ip = tokens[0].Replace("IP=", "");
                var message = tokens[1].Replace("message=", "").Replace("\'", "");
                var username = tokens[2].Replace("user=", "");
                User searchUser = users.FirstOrDefault(x => x.Username == username);

                if (searchUser != null)
                {
                    users.Find(x => x.Username == username).AddIp(ip);
                }
                else
                {
                    var user = new User(username);
                    user.AddIp(ip);
                    users.Add(user);
                }

                input = Console.ReadLine();
            }

            foreach (var user in users.OrderBy(x => x.Username))
            {
                Console.WriteLine($"{user.Username}:");
                Console.WriteLine($"{user.PrintIPs()}");
            }
        }
    }
}
