using System;

namespace _07._ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameArchitect = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());

            int hours = projectsCount * 3;
            Console.WriteLine("The architect {0} will need {1} hours to complete {2} project/s.",
                nameArchitect, hours, projectsCount);
        }
    }
}
