using System;

namespace GenericCountMethod
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            //Box<string> collection = new Box<string>();
            Box<double> collection = new Box<double>();

            for (int i = 0; i < linesCount; i++)
            {
                collection.Add(double.Parse(Console.ReadLine()));
            }

            //string elementToCompare = Console.ReadLine();
            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(collection.GetGreater(elementToCompare));
        }
    }
}
