using System;

namespace _04.Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int ballsCount = int.Parse(Console.ReadLine());

            double points = 0;
            int counterRed = 0;
            int counterOrange = 0;
            int counterYellow = 0;
            int counterWhite = 0;
            int counterBlack = 0;
            int counterOthers = 0;
           

            for (int balls = 1; balls <= ballsCount; balls++)
            {
                string colour = Console.ReadLine();

                switch (colour)
                {
                    case "red":
                        points += 5;
                        counterRed++;
                        break;

                    case "orange":
                        points += 10;
                        counterOrange++;
                        break;

                    case "yellow":
                        points += 15;
                        counterYellow++;
                        break;

                    case "white":
                        points += 20;
                        counterWhite++;
                        break;

                    case "black":
                        points /= 2;
                        counterBlack++;
                        break;

                    default:
                        points = points;
                        counterOthers++;
                        break;

                }

            }

            Console.WriteLine($"Total points: {Math.Floor(points)}");
            Console.WriteLine($"Points from red balls: {counterRed}");
            Console.WriteLine($"Points from orange balls: {counterOrange}");
            Console.WriteLine($"Points from yellow balls: {counterYellow}");
            Console.WriteLine($"Points from white balls: {counterWhite}");
            Console.WriteLine($"Other colors picked: {counterOthers}");
            Console.WriteLine($"Divides from black balls: {counterBlack}");
        }
    }
}
