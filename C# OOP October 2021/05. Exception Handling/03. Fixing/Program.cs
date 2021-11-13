using System;

namespace _03.Fixing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
            };
           
            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i]);
                }
                catch (IndexOutOfRangeException ior)
                {
                    Console.WriteLine(ior.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
