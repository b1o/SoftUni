using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.FootballLeague
{
    class FootballTeam
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Goals { get; set; }

        public FootballTeam(string name)
        {
            this.Name = name;
            this.Points = 0;
            this.Goals = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            List<FootballTeam> teams = new List<FootballTeam>();

            string input = Console.ReadLine();

            while (input != "final")
            {
                var tokens = ParseInput(input, key);
                int[] matchResult = tokens[2].Split(':').Select(int.Parse).ToArray();

                FootballTeam firstTeam;
                FootballTeam secondTeam;

                if (!teams.Any(t => t.Name == tokens[0]))
                {
                    firstTeam = new FootballTeam(tokens[0]);
                    teams.Add(firstTeam);
                }
                else
                {
                    firstTeam = teams.Find(t => t.Name == tokens[0]);
                }

                if (!teams.Any(t => t.Name == tokens[1]))
                {
                    secondTeam = new FootballTeam(tokens[1]);
                    teams.Add(secondTeam);
                }
                else
                {
                    secondTeam = teams.Find(t => t.Name == tokens[1]);
                }

                firstTeam.Goals += matchResult[0];
                secondTeam.Goals += matchResult[1];

                if (matchResult[0] > matchResult[1])
                {
                    firstTeam.Points += 3;
                } 
                else if (matchResult[0] < matchResult[1])
                {
                    secondTeam.Points += 3;
                }
                else
                {
                    firstTeam.Points++;
                    secondTeam.Points++;
                }

                input = Console.ReadLine();
            }

            teams = teams.OrderByDescending(t => t.Points).ThenBy(t => t.Name).ToList();

            Console.WriteLine("League standings:");
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i+1}. {teams[i].Name.ToUpper()} {teams[i].Points}");
            }

            var topGoals = teams.OrderByDescending(t => t.Goals).ThenBy(t => t.Name).Take(3);
            Console.WriteLine("Top 3 scored goals:");
            foreach (var footballTeam in topGoals)
            {
                Console.WriteLine($"- {footballTeam.Name.ToUpper()} -> {footballTeam.Goals}");
            }
        }

        public static List<string> ParseInput(string input, string key)
        {
            var tokens = input.Split();
            List<string> returnValue = new List<string>();

            foreach (var token in tokens)
            {
                if (token.Contains(key))
                {
                    int startIndex = token.IndexOf(key) + key.Length;
                    int endIndex = token.LastIndexOf(key);

                    string word = token.Substring(startIndex, endIndex-startIndex);

                    char[] result = word.ToCharArray();
                    Array.Reverse(result);
                    returnValue.Add(new string(result).ToLower());
                }
                else if (token.Contains(":"))
                {
                    returnValue.Add(token);   
                }
            }
            return returnValue;
        }
    }
}
