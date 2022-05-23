using System;

namespace _02.Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthShip = double.Parse(Console.ReadLine());
            double lenghtShip = double.Parse(Console.ReadLine());
            double heightShip = double.Parse(Console.ReadLine());
            double austronautsHeight = double.Parse(Console.ReadLine());

            double shipVolume = widthShip * lenghtShip * heightShip;

            double roomHeight = austronautsHeight + 0.40;
            const int roomLenght = 2;
            const int roomWidth = 2;

            double volumeOfOneRoom = roomHeight * roomWidth * roomLenght;

            double austronautsCount = Math.Floor(shipVolume / volumeOfOneRoom);

            if (austronautsCount >= 3 && austronautsCount <= 10 )
            {
                Console.WriteLine($"The spacecraft holds {austronautsCount} astronauts.");
            }
            else if (austronautsCount < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else if (austronautsCount > 10)
            {
                Console.WriteLine($"The spacecraft is too big.");
            }

        }
    }
}
