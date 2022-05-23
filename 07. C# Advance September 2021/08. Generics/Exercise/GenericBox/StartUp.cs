using System;

namespace GenericBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                // Box<string> box = new Box<string>(Console.ReadLine());  //Task 1
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
        }
    }
}
