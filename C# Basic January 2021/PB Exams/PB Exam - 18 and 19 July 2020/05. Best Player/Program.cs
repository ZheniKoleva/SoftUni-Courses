using System;

namespace _05.BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int goalsMax = int.MinValue;
            string bestPlayer = string.Empty;
            
            string playerName = Console.ReadLine();

            while (playerName != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > goalsMax)
                {
                    goalsMax = goals;
                    bestPlayer = playerName;
                }

                if (goals >= 10)
                {
                    break;
                }

                playerName = Console.ReadLine();

            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (goalsMax >= 3 )
            {
                Console.WriteLine($"He has scored {goalsMax} goals and made a hat-trick !!!");
            }
            else 
            {
                Console.WriteLine($"He has scored {goalsMax} goals.");
            }

        }
    }
}
