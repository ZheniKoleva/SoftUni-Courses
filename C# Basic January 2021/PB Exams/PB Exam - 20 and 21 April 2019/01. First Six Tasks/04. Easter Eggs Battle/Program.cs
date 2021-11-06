using System;

namespace _04.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsCountPlayer1 = int.Parse(Console.ReadLine());
            int eggsCountPlayer2 = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                switch (input)
                {
                    case "one":
                        eggsCountPlayer2--;                        
                        break;

                    case "two":
                        eggsCountPlayer1--;
                        break;
                }

                if (eggsCountPlayer1 == 0 || eggsCountPlayer2 == 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {eggsCountPlayer1} eggs left.");
                Console.WriteLine($"Player two has {eggsCountPlayer2} eggs left.");
            }
            else if (eggsCountPlayer1 == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {eggsCountPlayer2} eggs left.");
            }
            else if (eggsCountPlayer2 == 0)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {eggsCountPlayer1} eggs left.");
            }
        }
    }
}
