using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());

            int taskCount = 0;
            string lastTask = string.Empty;
            int gradesFailed = 0;
            double gradesSum = 0;

            string taskName = Console.ReadLine();

            while (taskName != "Enough")
            {
                int currentGrade = int.Parse(Console.ReadLine());
                if (currentGrade <= 4)
                {
                    gradesFailed++;                
                }

                if (gradesFailed == badGrades)
                {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    return;
                }
                taskCount++;
                lastTask = taskName;
                gradesSum += currentGrade;

                taskName = Console.ReadLine();
            }

            double averageGrade = gradesSum / taskCount;
            Console.WriteLine($"Average score: {averageGrade:f2}");
            Console.WriteLine($"Number of problems: {taskCount}");
            Console.WriteLine($"Last problem: {lastTask}");
        }
    }
}
