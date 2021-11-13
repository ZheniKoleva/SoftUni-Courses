using System;

namespace _05.ConvertToDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                double digit = Convert.ToDouble(input);
                Console.WriteLine(digit);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw fe;
            }           
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
                throw ofe;
            }
        }
    }
}
