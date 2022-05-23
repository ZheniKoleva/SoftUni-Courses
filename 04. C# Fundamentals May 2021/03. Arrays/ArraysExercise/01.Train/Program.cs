using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonCount = int.Parse(Console.ReadLine());

            int[] wagon = new int[wagonCount];
            int sum = 0;

            for (int i = 0; i < wagonCount; i++)
            {
                wagon[i] = int.Parse(Console.ReadLine());
                sum += wagon[i];
            }

            Console.WriteLine(string.Join(' ', wagon));

            //int sum = wagon.Sum();

            Console.WriteLine(sum);
        }
    }
}
