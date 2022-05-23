using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentsPoints = new Dictionary<string, int>();

            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "exam finished")
            {
                string[] parts = line
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string studentName = parts[0];

                if (parts.Length == 2)
                {
                    studentsPoints.Remove(studentName);
                    line = Console.ReadLine();
                    continue;
                }

                string language = parts[1];
                int points = int.Parse(parts[2]);

                CheckStudentPoints(studentsPoints, studentName, points);
                CheckSubmissions(submissions, language);

                line = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            Print(studentsPoints, '|');
            Console.WriteLine("Submissions:");
            Print(submissions, '-');

        }

        private static void Print(Dictionary<string, int> output, char delimiter)
        {
            output = output
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            //Console.WriteLine(delimiter.Equals('|') ? "Results:" : "Submissions:");

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} {delimiter} {item.Value}");
            }
            
        }

        private static void CheckSubmissions(Dictionary<string, int> submissions, string language)
        {
            if (!IsContestExist(submissions, language))
            {
                submissions.Add(language, 0);
            }

            submissions[language]++;
        }

        private static bool IsContestExist(Dictionary<string, int> submissions, string language)
        {
            return submissions.ContainsKey(language);
        }

        private static void CheckStudentPoints(Dictionary<string, int> studentsPoints, string studentName, int points)
        {
            if (!IsStudentExist(studentsPoints, studentName))
            {
                studentsPoints.Add(studentName, points);
            }
            else if (points > studentsPoints[studentName])
            {
                studentsPoints[studentName] = points;
            }
           
        }

        private static bool IsStudentExist(Dictionary<string, int> studentsPoints, string studentName)
        {
            return studentsPoints.ContainsKey(studentName);
        }
    }
}
