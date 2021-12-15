using System;
using System.Linq;

namespace GenericSwapMethod
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            Box<string> collection = new Box<string>();
            //Box<int> collection = new Box<int>();

            for (int i = 0; i < linesCount; i++)
            {
                collection.Add(Console.ReadLine());
                //collection.Add(int.Parse(Console.ReadLine()));
            }

            int[] indxesToSwap = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            collection.Swap(indxesToSwap[0], indxesToSwap[1]);
            Console.WriteLine(collection.ToString());
        }
    }
}
