using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double sumAllGrades = 0;
            int presentationCount = 0;

            while (presentationName != "Finish")
            {
                presentationCount++;
                double gradeSum = 0;

                for (int evaluation = 1; evaluation <= juryCount; evaluation++)
                {
                    gradeSum += double.Parse(Console.ReadLine());
                }
                
                sumAllGrades += gradeSum;
                Console.WriteLine($"{presentationName} - {(gradeSum / juryCount):f2}.");

                presentationName = Console.ReadLine();
            }

            double finalGrade = sumAllGrades / (juryCount * presentationCount);
            Console.WriteLine($"Student's final assessment is {finalGrade:f2}.");
        }
    }
}
