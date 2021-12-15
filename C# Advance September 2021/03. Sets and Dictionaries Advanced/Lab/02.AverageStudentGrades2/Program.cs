using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Student> studentsByGrades = new Dictionary<string, Student>();

            FillStudentsGrades(studentsByGrades, lines);
            Console.WriteLine(string.Join(Environment.NewLine, studentsByGrades.Values));
        }

        private static void FillStudentsGrades(Dictionary<string, Student> studentsByGrades, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (!studentsByGrades.ContainsKey(studentName))
                {
                    studentsByGrades.Add(studentName, new Student(studentName));
                }

                studentsByGrades[studentName].Grades.Add(grade);
            }
        }
    }

    public class Student
    {
        public Student(string name)
        {
            Name = name;
            Grades = new List<decimal>();
        }

        public string Name { get;}

        public List<decimal> Grades { get; set; }

        public override string ToString()
        {
            string grades = $"{string.Join(' ', Grades.Select(x => $"{x:f2}"))}";
            return $"{Name} -> {grades} (avg: {Grades.Average():f2})";
        }
    }
}
