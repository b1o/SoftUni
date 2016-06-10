using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentGroup
{
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }

        public Student(string name, string email, DateTime registerDate)
        {
            Name = name;
            Email = email;
            RegisterDate = registerDate;
        }

        public static Student Parse(string input)
        {
            char[] a = { '|' };
            string[] tokens = input.Split(a, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            string name = tokens[0];
            string email = tokens[1];
            DateTime register = DateTime.Parse(tokens[2]);

            return new Student(name, email, register);
        }
    }

    class Town
    {
        public static int Count = 0;

        private List<Group> groups;

        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }

        public List<Group> Groups
        {
            get
            {
                return this.groups;
            }
            set { this.groups = value; }
        }

        public Town(string name, int seatsCount)
        {
            Town.Count++;
            Name = name;
            SeatsCount = seatsCount;
            Students = new List<Student>();
            Groups = new List<Group>();
        }

        public void DistributeStudentsIntoGroups()
        {
            this.Students = this.Students.OrderBy(x => x.RegisterDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
            var studentsCopy = this.Students;
            int offset = 0;
            while (studentsCopy.Any())
            {
                var temp = studentsCopy.Take(this.SeatsCount).ToList();
                var group = new Group(this.Name, temp);
                studentsCopy = studentsCopy.Skip(this.SeatsCount).ToList();
                this.groups.Add(group);
            }
        }
    }

    class Group
    {
        public static int Count = 0;

        public string Town { get; set; }
        public List<Student> Students { get; set; }

        public Group(string town, List<Student> students)
        {
            Group.Count++;
            Town = town;
            Students = students;
        }

        public override string ToString()
        {
            return String.Join(", ", Students.Select(x => x.Email));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();
            string townInUsage = "";

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input.Contains("=>"))
                {
                    string[] tokens =
                        input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();
                    townInUsage = tokens[0];
                    var town = new Town(tokens[0], int.Parse(tokens[1].Split(' ')[0]));
                    towns.Add(town);
                }
                else
                {
                    var student = Student.Parse(input);
                    towns.Find(x => x.Name == townInUsage).Students.Add(student);
                }

                input = Console.ReadLine();
            }

            foreach (var town in towns)
            {
                town.DistributeStudentsIntoGroups();
            }

            Console.WriteLine($"Created {Group.Count} groups in {Town.Count} towns:");

            foreach (var town in towns.OrderBy(x => x.Name))
            {
                foreach (var group in town.Groups)
                {
                    Console.WriteLine($"{town.Name} => {group}");
                }
            }
        }
    }
}
