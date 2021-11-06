using System;

namespace _06.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            const double facebookFine = 150.00;
            const double instagramFine = 100.00;
            const double redditFine = 50.00;

            string siteName = string.Empty;

            for (int i = 0; i < openTabs; i++)
            {
                siteName = Console.ReadLine().ToLower();
                switch (siteName)
                {
                    case "facebook":
                        salary -= facebookFine;
                        break;
                    case "instagram":
                        salary -= instagramFine;
                        break;
                    case "reddit":
                        salary -= redditFine;
                        break;
                   
                }

                if (salary <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine($"{Math.Truncate(salary)}");
            }
        }
    }
}
