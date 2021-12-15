using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> students = new SortedDictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> studentsPoint = new Dictionary<string, int>();

            string line;

            while ((line = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = ExtractData(line, ":");
                FillContestsData(passwords, contestData);
            }

            while ((line = Console.ReadLine()) != "end of submissions")
            {
                string[] studentData = ExtractData(line, "=>");

                string contest = studentData[0];
                string password = studentData[1];

                if (!passwords.ContainsKey(contest)
                   || !passwords[contest].Equals(password))
                {
                    continue;
                }

                string student = studentData[2];
                int points = int.Parse(studentData[3]);               

                FillStudentsData(students, studentsPoint, contest, student, points);
            }

            PrintStatistics(students, studentsPoint);
        }

        private static void FillContestsData(Dictionary<string, string> passwords, string[] contestData)
        {
            string contest = contestData[0];
            string password = contestData[1];

            if (!passwords.ContainsKey(contest))
            {
                passwords.Add(contest, null);
            }

            passwords[contest] = password;
        }

        private static string[] ExtractData(string line, string delimiter)
        {
            return line
                  .Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void PrintStatistics(SortedDictionary<string, Dictionary<string, int>> students, Dictionary<string, int> studentsPoint)
        {
            string bestStudent = studentsPoint
                .OrderByDescending(x => x.Value)
                .First().Key;

            Console.WriteLine($"Best candidate is {bestStudent} with total {studentsPoint[bestStudent]} points.");

            Console.WriteLine("Ranking:");

            foreach (var (student, contests) in students)
            {
                Console.WriteLine(student);

                foreach (var (name, points) in contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {name} -> {points}");
                }
            }
        }

        private static void FillStudentsData(SortedDictionary<string, Dictionary<string, int>> students, Dictionary<string, int> studentsPoint, string contest, string student, int points)
        {
            if (!students.ContainsKey(student))
            {
                students.Add(student, new Dictionary<string, int>());
                studentsPoint.Add(student, 0);
            }

            if (!students[student].ContainsKey(contest))
            {
                students[student].Add(contest, 0);
            }

            if (students[student][contest] < points)
            {
                students[student][contest] = points;
                studentsPoint[student] = students[student].Values.Sum();
            }
        }
    }    
}
