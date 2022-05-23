using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsByGrades = new Dictionary<string, List<decimal>>();

            FillStudentsGrades(studentsByGrades, lines);

            PrintStudents(studentsByGrades);
        }

        private static void PrintStudents(Dictionary<string, List<decimal>> studentsByGrades)
        {
            foreach (var (student, grades) in studentsByGrades)
            {
                Console.WriteLine($"{student} -> {string.Join(' ', grades.Select(x => $"{x:f2}"))} (avg: {grades.Average():f2})");
            }
        }

        private static void FillStudentsGrades(Dictionary<string, List<decimal>> studentsByGrades, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (!studentsByGrades.ContainsKey(studentName))
                {
                    studentsByGrades.Add(studentName, new List<decimal>());
                }

                studentsByGrades[studentName].Add(grade);
            }
        }
    }
}
