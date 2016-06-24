namespace _01.Cubic_Artillery
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            Queue<int> weapons = new Queue<int>();
            Queue<string> bunkers = new Queue<string>();
            int currentBunkerCapacity = 0;

            string input = Console.ReadLine();

            while (input != "Bunker Revision")
            {
                var tokens = input.Split();
                int weapon;
                foreach (var token in tokens)
                {
                    if (int.TryParse(token, out weapon))
                    {
                        if (currentBunkerCapacity + weapon <= maxCapacity)
                        {
                            weapons.Enqueue(weapon);
                            currentBunkerCapacity += weapon;
                        }
                        else
                        {
                            if (bunkers.Count > 1)
                            {
                                string result = weapons.Count > 0 ? string.Join(", ", weapons) : "Empty";
                                currentBunkerCapacity = 0;
                                Console.WriteLine($"{bunkers.Dequeue()} -> {result}");
                                weapons.Clear();

                                if (currentBunkerCapacity + weapon <= maxCapacity)
                                {
                                    weapons.Enqueue(weapon);
                                    currentBunkerCapacity += weapon;
                                }
                            }
                            else
                            {
                                if (weapon <= maxCapacity)
                                {
                                    while (currentBunkerCapacity + weapon > maxCapacity)
                                    {
                                        currentBunkerCapacity -= weapons.Dequeue();
                                    }

                                    weapons.Enqueue(weapon);
                                    currentBunkerCapacity += weapon;
                                }
                            }
                        }
                    }
                    else
                    {
                        bunkers.Enqueue(token);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
