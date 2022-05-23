using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGradeByWord(grade);
        }

        private static void PrintGradeByWord(double grade)
        {
            string output = string.Empty;

            if (grade >= 2.00 && grade < 3.00)
            {
                output = "Fail";
            }
            else if (grade < 3.50)
            {
                output = "Poor";
            }
            else if (grade < 4.50)
            {
                output = "Good";
            }
            else if (grade < 5.50)
            {
                output = "Very good";
            }
            else if (grade <= 6.00)
            {
                output = "Excellent";
            }

            Console.WriteLine(output);
        }
    }
}

