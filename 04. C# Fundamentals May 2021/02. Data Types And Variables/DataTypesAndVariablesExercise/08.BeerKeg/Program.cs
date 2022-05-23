using System;

namespace _08.BeerKeg
{
    class Program
    {
        static void Main(string[] args)
        {
            byte kegsCount = byte.Parse(Console.ReadLine());

            double volumeMax = 0;
            string modelMax = string.Empty;

            for (int i = 0; i < kegsCount; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * (Math.Pow(radius, 2)) * height;

                if (volume > volumeMax)
                {
                    volumeMax = volume;
                    modelMax = model;
                }
            }

            Console.WriteLine(modelMax);
        }
    }
}
