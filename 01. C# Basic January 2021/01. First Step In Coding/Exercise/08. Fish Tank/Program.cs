using System;

namespace _08._FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentOccupiedSpace = double.Parse(Console.ReadLine());

            double aquariumVolume = (lenght * width * height) * 0.001;
            double occupiedVolume = aquariumVolume * (percentOccupiedSpace * 0.01);
            double freeSpace = aquariumVolume - occupiedVolume;
            Console.WriteLine(freeSpace);
        }
    }
}
