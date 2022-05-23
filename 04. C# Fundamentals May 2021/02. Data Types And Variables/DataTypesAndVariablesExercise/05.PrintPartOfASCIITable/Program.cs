using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            //for (int i = startNum; i <= endNum; i++)
            //{
            //    Console.Write($"{(char)i} ");
            //}

            for (char i = (char)startNum; i <= endNum ; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
