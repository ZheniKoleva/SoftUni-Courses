using System;

namespace _08.GraduationPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
           
            int levelPassed = 0;
            int countFailed = 0;
            double sumAllGrades = 0.00;
            bool isGraduate = false;

            while (!isGraduate)
            {
                double yearlyGrade = double.Parse(Console.ReadLine());

                if (yearlyGrade < 4.00)
                {
                    countFailed++;
                }

                if (countFailed == 2)
                {
                    break;
                }
                levelPassed++;
                sumAllGrades += yearlyGrade;
                if (levelPassed == 12)
                {
                    isGraduate = true;
                }
            }

            if (isGraduate)
            {
                double averageGrade = sumAllGrades / levelPassed;
                Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
            }
            else
            {
                Console.WriteLine($"{studentName} has been excluded at {levelPassed} grade");
            }
        }
    }
}
