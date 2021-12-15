using System;

namespace GenericThreeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = ReadData();
            string fullName = string.Join(' ', data[0..2]);
            string address = data[2];
            string town = string.Join(' ', data[3..]);
            Threeuple<string, string, string> first = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(first);

            data = ReadData();
            string name = data[0];
            int beer = int.Parse(data[1]);
            bool isDrunk = data[2] == "drunk";
            Threeuple<string, int, bool> second = new Threeuple<string, int, bool>(name, beer, isDrunk);
            Console.WriteLine(second);

            data = ReadData();
            string personName = data[0];
            double accountBalance = double.Parse(data[1]);
            string bank = string.Join(' ', data[2..]);
            Threeuple<string, double, string> third = new Threeuple<string, double, string>
                (personName, accountBalance, bank);
            Console.WriteLine(third);
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
