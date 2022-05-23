using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeVolume = width * lenght * height;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                freeVolume -= int.Parse(input);

                if (freeVolume < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeVolume)} Cubic meters more.");
                    return;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{freeVolume} Cubic meters left.");            
        }
    }
}
