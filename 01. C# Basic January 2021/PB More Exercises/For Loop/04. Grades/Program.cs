using System;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            int counterTop = 0;
            int counterGood = 0;
            int counterAverage = 0;
            int counterFail = 0;
            double gradeTotal = 0.00;

            for (int i = 0; i < studentsNumber; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradeTotal += grade;

                if (grade >= 5)
                {
                    counterTop += 1;                   
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    counterGood += 1;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    counterAverage += 1;
                }
                else if (grade < 3)
                {
                    counterFail += 1;
                }
            }
            double averageGrade = gradeTotal / studentsNumber;
            double percentExcellent = (counterTop * 100.00) / studentsNumber;
            double percentGood = (counterGood * 100.00) / studentsNumber;
            double percentAverage = (counterAverage * 100.00) / studentsNumber;
            double percentFail = (counterFail * 100.00) / studentsNumber;

            Console.WriteLine($"Top students: {percentExcellent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentGood:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentAverage:f2}%");
            Console.WriteLine($"Fail: {percentFail:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
