using System;

namespace _08._Scholarship2
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScolarship = Math.Floor(minSalary * 0.35);
            double excellentScolarship = Math.Floor(averageGrade * 25);

            if ((income < minSalary && averageGrade > 4.50 && averageGrade >= 5.50 && excellentScolarship >= socialScolarship)
                || averageGrade >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScolarship} BGN");
            }
            else if ((income < minSalary && averageGrade > 4.50 && averageGrade >= 5.50 && excellentScolarship < socialScolarship)
                || (income < minSalary && averageGrade > 4.50))
            {
                Console.WriteLine($"You get a Social scholarship {socialScolarship} BGN");
            }                      
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
