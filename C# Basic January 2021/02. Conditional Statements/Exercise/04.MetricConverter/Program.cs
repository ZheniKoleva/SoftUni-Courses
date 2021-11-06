using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            string inputValue = Console.ReadLine();
            string outputValue = Console.ReadLine();
            

            if (inputValue.Equals("mm") && outputValue.Equals("cm"))
            {
                input /= 10;
            }
            else if (inputValue.Equals("mm") && outputValue.Equals("m"))
            {
                input /= 1000;
            }
            else if (inputValue.Equals("cm") && outputValue.Equals("m"))
            {
                input /= 100;
            }
            else if (inputValue.Equals("cm") && outputValue.Equals("mm"))
            {
                input *= 10;
            }
            else if (inputValue.Equals("m") && outputValue.Equals("cm"))
            {
                input *= 100;
            }
            else if (inputValue.Equals("m") && outputValue.Equals("mm"))
            {
                input *= 1000;
            }
            Console.WriteLine($"{input:f3}");
        }
    }
}
