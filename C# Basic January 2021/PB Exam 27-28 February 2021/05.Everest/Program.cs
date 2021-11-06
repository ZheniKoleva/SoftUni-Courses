using System;

namespace _05.Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = 1;
            double startHeight = 5364;
            double endHeight = 8848;            
            bool isClimbed = false;

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Yes")
                {
                    daysCount++;
                }

                if (daysCount > 5)                
                {                   
                    break;
                }

                startHeigh += double.Parse(Console.ReadLine());

                if (startHeight >= endHeight)
                {
                    isClimbed = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isClimbed)
            {
                Console.WriteLine($"Goal reached for {daysCount} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{startHeight}");
            }
        }
    }
}
