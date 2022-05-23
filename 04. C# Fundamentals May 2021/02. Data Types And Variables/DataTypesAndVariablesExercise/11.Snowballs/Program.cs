using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte snowballsCount = byte.Parse(Console.ReadLine());

            BigInteger maxValue = 0;
            string output = string.Empty;

            for (int i = 0; i < snowballsCount; i++)
            {
                ushort snowballSnow = ushort.Parse(Console.ReadLine());
                ushort snowballTime = ushort.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > maxValue)
                {
                    maxValue = snowballValue;
                    output = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
                }

            }

            Console.WriteLine(output);

        }
    }
}
