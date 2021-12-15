using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.DateDifference(firstDate, secondDate));
        }
    }
}
