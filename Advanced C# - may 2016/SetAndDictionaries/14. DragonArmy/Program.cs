using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    class Dragon
    {
        public int? Damage { get; set; }
        public int? Health { get; set; }
        public int? Armor { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Dragon(string name, string type, int? damage = 45, int? health = 250, int? armor = 10)
        {
            this.Name = name;
            this.Damage = damage ?? 45;
            this.Health = health ?? 250;
            this.Armor = armor ?? 10;
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is Dragon && this.Equals((Dragon) obj);
        }

        public bool Equals(Dragon dragon)
        {
            return this.Name == dragon.Name && this.Type == dragon.Type;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Dragon>dragons = new List<Dragon>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                int? damage;
                int? health;
                int? armor;
                int temp;
                var a = int.TryParse(input[2], out temp) ? damage = temp : damage = null;
                a = int.TryParse(input[3], out temp) ? health = temp : health = null;
                a = int.TryParse(input[4], out temp) ? armor = temp : armor = null;

                Dragon dragon = new Dragon(name, type, damage, health, armor);
                var dummy = dragons.FirstOrDefault(x => x.Name == dragon.Name && x.Type == dragon.Type);
                if (dummy != null)
                {
                    dummy.Armor = dragon.Armor;
                    dummy.Damage = dragon.Damage;
                    dummy.Health = dragon.Health;
                }
                else
                {
                    dragons.Add(dragon);
                }
            }

            var result = dragons.GroupBy(x => x.Type).ToDictionary(x => x.Key, x => x.ToList());
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key}::({pair.Value.Average(x => x.Damage):f}/{pair.Value.Average(x => x.Health):f}/{pair.Value.Average(x => x.Armor):f})");
                foreach (var dragon in pair.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}
