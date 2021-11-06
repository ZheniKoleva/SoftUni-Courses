using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int goal = 10000;

            int sumSteps = 0;           

            while (sumSteps < goal)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    sumSteps += int.Parse(Console.ReadLine());
                    break;
                }
                sumSteps += int.Parse(input);

            }

            int difference = sumSteps - goal;
            if (sumSteps >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{difference} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(difference)} more steps to reach goal.");
            }
        }
    }
}
