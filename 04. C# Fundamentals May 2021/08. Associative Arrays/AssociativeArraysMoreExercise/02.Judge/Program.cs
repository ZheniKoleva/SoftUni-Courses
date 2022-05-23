using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestsList = new Dictionary<string, Dictionary<string, int>>();            

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] parts = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string userName = parts[0];
                string contest = parts[1];
                int points = int.Parse(parts[2]);

                if (!IsContestExists(contestsList, contest)) // дали го има контеста
                {
                    contestsList.Add(contest, new Dictionary<string, int>());
                    contestsList[contest].Add(userName, points);
                }
                else  if (!IsStudentExists(contestsList, contest, userName)) // дали го има човека в този контест
                {
                    contestsList[contest].Add(userName, points);
                }
                else if (IsPointsBigger(contestsList, contest, userName, points)) // дали резултата му е по-добър от предходният
                {   
                    contestsList[contest][userName] = points;
                }                

                input = Console.ReadLine();
            }

            Dictionary<string, int> students = new Dictionary<string, int>();

            FillIndividualStatistic(students, contestsList);

            PrintContestStatistic(contestsList);           

            Console.WriteLine("Individual standings:");

            PrintIndividualStatistic(students, "->");
        }

        private static void FillIndividualStatistic(Dictionary<string, int> students, Dictionary<string, Dictionary<string, int>> contestsList)
        {
            foreach (var contest in contestsList)
            {
                foreach (var student in contest.Value)
                {
                    if (!students.ContainsKey(student.Key)) //дали го има като цяло
                    {
                        students.Add(student.Key, student.Value);
                    }
                    else
                    {
                        students[student.Key] += student.Value;
                    }
                }
            }
        }

        private static bool IsPointsBigger(Dictionary<string, Dictionary<string, int>> contestsList, string contest, string userName, int points)
        {
            return contestsList[contest][userName] < points;
        }

        private static bool IsStudentExists(Dictionary<string, Dictionary<string, int>> contestsList, string contest, string userName)
        {
            return contestsList[contest].ContainsKey(userName);
        }

        private static bool IsContestExists(Dictionary<string, Dictionary<string, int>> contestsList, string contest)
        {
            return contestsList.ContainsKey(contest);
        }


        private static void PrintIndividualStatistic(Dictionary<string, int> dictionary, string delimiter)
        {
            var collection = dictionary
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);                    

            int counter = 1;

            foreach (var item in collection)
            {
                Console.WriteLine($"{counter++}. {item.Key} {delimiter} {item.Value}");
            }
        }


        private static void PrintContestStatistic(Dictionary<string, Dictionary<string, int>> contestsList)
        {
            foreach (var contest in contestsList)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");                

                PrintIndividualStatistic(contest.Value, "<::>");
            }
        }
    }
}
