using System;

namespace GenericTuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = ReadData();
            string name = string.Join(' ', data[0..2]);
            string address = data[2];
            Tuple<string, string> firstTuple = new Tuple<string, string>(name, address);
            Console.WriteLine(firstTuple);

            data = ReadData();
            string personName = data[0];
            int beerLiters = int.Parse(data[1]);
            Tuple<string, int> secondTuple = new Tuple<string, int>(personName, beerLiters);
            Console.WriteLine(secondTuple);

            data = ReadData();
            int firstNum = int.Parse(data[0]);
            double secondNum = double.Parse(data[1]);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(firstNum, secondNum);
            Console.WriteLine(thirdTuple);
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
