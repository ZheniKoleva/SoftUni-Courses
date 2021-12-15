namespace _04.Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Lake stones = new Lake(Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse));

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
