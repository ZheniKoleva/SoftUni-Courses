using System;

namespace _04.GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer1 = Console.ReadLine();
            string namePlayer2 = Console.ReadLine();

            int pointsPlayer1 = 0;
            int pointsPlayer2 = 0;

            string input = Console.ReadLine();

            while (input != "End of game")
            {
                int card1 = int.Parse(input);
                int card2 = int.Parse(Console.ReadLine());

                if (card1 > card2)
                {
                    pointsPlayer1 += card1 - card2;
                }
                if (card1 < card2)
                {
                    pointsPlayer2 += card2 - card1;
                }
                else if (card1 == card2)
                {
                    Console.WriteLine("Number wars!");
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());
                    if (card1 > card2)
                    {
                        Console.WriteLine($"{namePlayer1} is winner with {pointsPlayer1} points");
                    }
                    else
                    {
                        Console.WriteLine($"{namePlayer2} is winner with {pointsPlayer2} points");
                    }
                    break;

                }

                input = Console.ReadLine();
            }

            if (input == "End of game")
            {
                Console.WriteLine($"{namePlayer1} has {pointsPlayer1} points");
                Console.WriteLine($"{namePlayer2} has {pointsPlayer2} points");
            }
        }
    }
}
