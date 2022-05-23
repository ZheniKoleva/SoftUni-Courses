using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestData = new Dictionary<string, string>();

            FillContestData(contestData);

            SortedDictionary<string, List<Contest>> students = new SortedDictionary<string, List<Contest>>();

            FillStudentData(contestData, students);

            Console.WriteLine(TakeBestCandidate(students));

            Console.WriteLine("Ranking: ");

            Print(students);

        }

        private static void Print(SortedDictionary<string, List<Contest>> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.Key);                
                Console.WriteLine(string.Join(Environment.NewLine, student.Value.OrderByDescending(x => x.Points)));
            }
        }

        private static string TakeBestCandidate(SortedDictionary<string, List<Contest>> students)
        {  
            int pointsMax = students
                .Max(x => x.Value.Sum(y => y.Points));

            string name = students
                .First(x => x.Value.Sum(y => y.Points) == pointsMax)
                .Key;

            return $"Best candidate is {name} with total {pointsMax} points.";
                
        }

        private static void FillStudentData(Dictionary<string, string> contestData, SortedDictionary<string, List<Contest>> students)
        {
            string line = Console.ReadLine();

            while (line != "end of submissions")
            {
                string[] data = DivideInputData(line, "=>");

                string contest = data[0];
                string password = data[1];
                string studentName = data[2];
                int points = int.Parse(data[3]);

                if (!CheckIfContestExist(contestData, contest) 
                    || !CheckIsPasswordValid(contestData, contest, password))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!CheckIfStudentExist(students, studentName))
                {
                    students.Add(studentName, new List<Contest> { new Contest(contest, points) });
                }

                if (!IsStudentSolvesContest(students, studentName, contest)) //има ли го контеста в досието на студента
                {
                    students[studentName].Add(new Contest(contest, points));
                }
                else 
                {
                    Contest currentPoint = students[studentName].First(x => x.Name == contest);

                    if (currentPoint.Points < points)
                    {
                        currentPoint.Points = points;
                    }
                }


                line = Console.ReadLine();
            }
        }

        private static bool IsStudentSolvesContest(SortedDictionary<string, List<Contest>> students, string studentName, string contest)
        {
            return students[studentName].Any(x => x.Name == contest);
        }

        private static bool CheckIfStudentExist(SortedDictionary<string, List<Contest>> students, string studentName)
        {
            return students.ContainsKey(studentName);
        }

        private static bool CheckIsPasswordValid(Dictionary<string, string> contestData, string contest, string password)
        {
            return contestData[contest] == password;
        }

        private static bool CheckIfContestExist(Dictionary<string, string> contestData, string contest)
        {
            return contestData.ContainsKey(contest);
        }

        private static void FillContestData(Dictionary<string, string> contestData)
        {  
            string line = Console.ReadLine();

            while (line != "end of contests")
            {
                string[] data = DivideInputData(line, ":");

                string contestName = data[0];
                string password = data[1];

                contestData.Add(contestName, password);
                line = Console.ReadLine();
            }
            
        }

        private static string[] DivideInputData(string line, string delimiter)
        {
            return line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    //public class Contest
    //{
    //    public Contest(string name, int points)
    //    {
    //        this.Name = name;
    //        this.Points = points;
    //    }

    //    public string Name { get; private set; }

    //    public int Points { get; set; }


    //    public override string ToString()
    //    {
    //        return $"#  {Name} -> {Points}";
    //    }

    //}
}
