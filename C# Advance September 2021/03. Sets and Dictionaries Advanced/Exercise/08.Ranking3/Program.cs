using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Ranking3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            SortedDictionary<string, Student> students = new SortedDictionary<string, Student>();
            
            string line;

            while ((line = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = ExtractData(line, ":");

                FillContestData(passwords, contestData);
            }

            while ((line = Console.ReadLine()) != "end of submissions")
            {
                string[] studentData = ExtractData(line, "=>");

                string contest = studentData[0];
                string password = studentData[1];

                if (!IsContestDataValid(passwords, contest, password))
                {
                    continue;
                }

                string student = studentData[2];
                int points = int.Parse(studentData[3]);

                FillStudentsData(students, contest, student, points);
            }

            Student bestStudent = students
                .OrderByDescending(x => x.Value.Points)
                .First().Value;

            Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.Points} points.");

            Console.WriteLine("Ranking:");

            foreach (var student in students.Values)
            {
                Console.WriteLine(student);
            }
        }

        private static bool IsContestDataValid(Dictionary<string, string> passwords, string contest, string password)
        {
            return passwords.ContainsKey(contest) && passwords[contest].Equals(password);
        }

        private static void FillStudentsData(SortedDictionary<string, Student> students, string contest, string student, int points)
        {
            if (!students.ContainsKey(student))
            {
                students.Add(student, new Student(student));
            }

            if (!students[student].Contests.ContainsKey(contest))
            {
                students[student].Contests.Add(contest, 0);
            }

            if (students[student].Contests[contest] < points)
            {
                students[student].Contests[contest] = points;
                students[student].CalculatePoints();
            }
        }

        private static void FillContestData(Dictionary<string, string> passwords, string[] contestData)
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
    }

    public class Student
    {
        public Student(string name)
        {
            Name = name;
            Contests = new Dictionary<string, int>();
        }

        public string Name { get; }

        public Dictionary<string, int> Contests { get; set; }

        public int Points { get; private set; }       

        public int CalculatePoints()
        {
            return this.Points = Contests.Values.Sum();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(Name);

            foreach (var (contest, points) in Contests.OrderByDescending(x => x.Value))
            {
                output.AppendLine($"#  {contest} -> {points}");
            }
            return output.ToString().TrimEnd();
        }

    }
    
}
