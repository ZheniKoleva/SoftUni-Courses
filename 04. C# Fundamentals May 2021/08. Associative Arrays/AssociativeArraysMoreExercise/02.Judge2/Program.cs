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

            Dictionary<string, int> usersPoints = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] parts = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string userName = parts[0];
                string contest = parts[1];
                int points = int.Parse(parts[2]);


                if (!contestsList.ContainsKey(contest)) // дали го има контеста
                {
                    contestsList.Add(contest, new Dictionary<string, int>());
                    contestsList[contest].Add(userName, points);
                }

                if (!contestsList[contest].ContainsKey(userName)) // дали го има човека в този контест
                {
                    contestsList[contest].Add(userName, points);
                }

                int oldResult = contestsList[contest][userName];             

                if (oldResult < points) // дали резултата му е по-добър от предходният
                {    
                    contestsList[contest][userName] = points;                   
                }
                
                input = Console.ReadLine();
            }

            foreach (var contest in contestsList)
            {
                foreach (var student in contest.Value)
                {
                    if (!usersPoints.ContainsKey(student.Key)) //дали го има като цяло
                    {
                        usersPoints.Add(student.Key, student.Value);
                    }
                    else
                    {
                        usersPoints[student.Key] += student.Value;
                    }
                }
            }

            PrintContestStatistic(contestsList);

            usersPoints = usersPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Individual standings:");

            PrintIndividualStatistic(usersPoints);
        }

        private static void PrintIndividualStatistic(Dictionary<string, int> usersPoints)
        {
            int counter = 1;

            foreach (var user in usersPoints)
            {
                Console.WriteLine($"{counter++}. {user.Key} -> {user.Value}");
            }
        }

        private static void PrintContestStatistic(Dictionary<string, Dictionary<string, int>> contestsList)
        {
            foreach (var contest in contestsList)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                Dictionary<string, int> current = contest.Value;

                current = current
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                int counter = 1;

                foreach (var item in current)
                {
                    Console.WriteLine($"{counter++}. {item.Key} <::> {item.Value}");

                }

            }
        }
    }
}
