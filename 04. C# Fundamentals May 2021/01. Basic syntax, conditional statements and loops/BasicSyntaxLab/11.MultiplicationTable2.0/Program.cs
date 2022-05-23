using System;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int startNum = int.Parse(Console.ReadLine());

            int result = 0;

            if (startNum > 10)
            {
                result = number * startNum;

                Console.WriteLine($"{number} X {startNum} = {result}");
            }
            else
            {
                for (int i = startNum; i <= 10; i++)
                {
                    result = number * i;

                    Console.WriteLine($"{number} X {i} = {result}");
                }

            }
        }
    }
}
