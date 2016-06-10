using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade
        {
            get { return this.Grades.Average(); }
        }

        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        public static Student Parse(string input)
        {
            string[] tokens = input.Split(' ');
            string name = tokens[0];
            List<double> grades = new List<double>();

            for (int i = 1; i < tokens.Length; i++)
            {
                grades.Add(double.Parse(tokens[i], CultureInfo.InvariantCulture));
            }

            return new Student(name, grades);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                students.Add(Student.Parse(Console.ReadLine()));
            }

            var result = students.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f}");
            }
        }
    }
}
