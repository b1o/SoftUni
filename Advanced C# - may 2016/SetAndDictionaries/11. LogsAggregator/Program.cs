using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LogsAggregator
{
    class User
    {
        public string Name { get; set; }
        public SortedSet<string> IPs { get; set; }
        public int TotalDuration { get; set; }

        public User(string name, string ips, int duration)
        {
            this.Name = name;
            this.IPs = new SortedSet<string>();
            this.IPs.Add(ips);
            this.TotalDuration = duration;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int logCount = int.Parse(Console.ReadLine());
            List<User> users = new List<User>();

            for (int i = 0; i < logCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                string ip = tokens[0];
                string name = tokens[1];
                int duration = int.Parse(tokens[2]);

                var dummy = users.FirstOrDefault(x => x.Name == name);
                if (dummy != null)
                {
                    dummy.IPs.Add(ip);
                    dummy.TotalDuration += duration;
                }
                else
                {
                    users.Add(new User(name, ip, duration));
                }
            }

            foreach (var user in users.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{user.Name}: {user.TotalDuration} [{string.Join(", ", user.IPs)}]");
            }
        }
    }
}
