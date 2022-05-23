using System;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();

            int points = 301;
            int successfullShots = 0;
            int unsuccessfullShots = 0;
            string input = Console.ReadLine();

            while (input != "Retire")
            {
                int currentPoints = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case "Single":
                        if (currentPoints > points)
                        {
                            unsuccessfullShots++;
                            break;
                        }
                        else
                        {
                            points -= currentPoints;
                            successfullShots++;
                        }                       
                        break;

                    case "Double":
                        if (currentPoints * 2 > points)
                        {
                            unsuccessfullShots++;
                            break;
                        }
                        else
                        {
                            points -= currentPoints * 2;
                            successfullShots++;
                        }                        
                        break;

                    case "Triple":
                        if (currentPoints * 3 > points)
                        {
                            unsuccessfullShots++;
                            break;
                        }
                        else
                        {
                            points -= currentPoints * 3;
                            successfullShots++;
                        }                        
                        break;
                }              

                if (points <= 0)
                {
                    Console.WriteLine($"{playerName} won the leg with {successfullShots} shots.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Retire")
            {
                Console.WriteLine($"{playerName} retired after {unsuccessfullShots} unsuccessful shots.");
            }
        }
    }
}
