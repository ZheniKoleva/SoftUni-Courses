using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = ReadInput();

            string line = Console.ReadLine();

            while (line != "course start")
            {
                string[] tokens = line.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string lesson = tokens[1];

                switch (command)
                {
                    case "Add":
                        if (!courses.Contains(lesson))
                        {
                            courses.Add(lesson);
                        }

                        break;

                    case "Insert":
                        int indx = int.Parse(tokens[2]);

                        if (!courses.Contains(lesson))
                        {
                            courses.Insert(indx, lesson);
                        }

                        break;

                    case "Remove":
                        courses.Remove(lesson);

                        string exerciseName = GetExerciseName(lesson);
                        courses.Remove(exerciseName);
                        break;

                    case "Swap":
                        string lesson2 = tokens[2];

                        if (IsLessonsExists(courses, lesson, lesson2))
                        {
                            SwapLessons(courses, lesson, lesson2);
                        }

                        string exercise1 = GetExerciseName(lesson);
                        string exercise2 = GetExerciseName(lesson2);

                        if (IsLessonsExists(courses, exercise1, exercise2))
                        {
                            SwapLessons(courses, lesson, lesson2);
                        }
                        else if (IsLessonsExists(courses, exercise1))
                        {
                            RepositionOfExercise(courses, lesson, exercise1); 
                        }
                        else if (IsLessonsExists(courses, exercise2))
                        {
                            RepositionOfExercise(courses, lesson2, exercise2);
                        }
                        break;

                    case "Exercise":
                        string exercise = GetExerciseName(lesson); 
                        AddExercise(courses, lesson, exercise); 
                        break;
                }


                line = Console.ReadLine();
            }

            Print(courses);


        }

        private static void RepositionOfExercise(List<string> courses, string lesson, string exercise1)
        {
            int indxOfLesson = courses.IndexOf(lesson);
            courses.Remove(exercise1);
            courses.Insert(indxOfLesson + 1, exercise1);
        }

        private static void Print(List<string> courses)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }

        private static string GetExerciseName(string lesson)
        {
            StringBuilder exerciseName = new StringBuilder();
            exerciseName.Append(lesson);
            exerciseName.Append("-Exercise");

            return exerciseName.ToString();
        }

        private static void AddExercise(List<string> courses, string lesson, string exercise)
        {
            if (courses.Contains(lesson) && !courses.Contains(exercise))
            {
                int indxOfLesson = courses.IndexOf(lesson);
                courses.Insert(indxOfLesson + 1, exercise);
            }
            else if (!courses.Contains(lesson))
            {
                courses.Add(lesson);
                courses.Add(exercise);
            }
        }

        private static void SwapLessons(List<string> courses, string lesson, string lesson2)
        {
            int indxOfFirst = courses.IndexOf(lesson);
            int indxOfSecond = courses.IndexOf(lesson2);

            string temp = courses[indxOfFirst];
            courses[indxOfFirst] = courses[indxOfSecond];
            courses[indxOfSecond] = temp;
        }

        private static bool IsLessonsExists(List<string> courses, string lesson, string lesson2)
        {
            return courses.Contains(lesson) && courses.Contains(lesson2);
        }

        private static bool IsLessonsExists(List<string> courses, string lesson)
        {
            return courses.Contains(lesson);
        }

        private static List<string> ReadInput()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)                
                .ToList();
        }
    }
}
