using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int piecesCake = width * lenght;
            bool isFinished = false;

            while (!isFinished)
            {
                string piecesTaken = Console.ReadLine();

                if (piecesTaken == "STOP")
                {
                    break;
                }

                piecesCake -= int.Parse(piecesTaken);
                if (piecesCake < 0)
                {
                    isFinished = true;
                    break;
                }
            }

            if (isFinished)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(piecesCake)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{piecesCake} pieces are left.");
            }
        }
    }
}
