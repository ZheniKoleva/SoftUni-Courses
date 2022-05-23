using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] data = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = data[0];
                string studentName = data[1];

                FillData(courses, courseName, studentName);

                line = Console.ReadLine();
            }            

            Print(courses);
        }

        private static void Print(Dictionary<string, List<string>> courses)
        {
            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                course.Value.Sort();

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }

        private static void FillData(Dictionary<string, List<string>> courses, string courseName, string studentName)
        {
            if (!courses.ContainsKey(courseName))
            {
                courses.Add(courseName, new List<string>());
            }

            courses[courseName].Add(studentName);
        }
    }
}
