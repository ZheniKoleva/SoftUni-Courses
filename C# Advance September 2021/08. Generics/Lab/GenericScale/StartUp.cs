using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> integers = new EqualityScale<int>(5, 5);
            Console.WriteLine(integers.AreEqual());

            EqualityScale<string> strings = new EqualityScale<string>("Pesho", "Gosho");
            Console.WriteLine(strings.AreEqual());

            EqualityScale<string> strings2 = new EqualityScale<string>("Pesho", "Pesho");
            Console.WriteLine(strings2.AreEqual());
        }
    }
}
