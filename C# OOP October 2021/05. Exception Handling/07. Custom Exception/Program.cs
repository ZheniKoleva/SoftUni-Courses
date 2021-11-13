using System;

namespace _07.CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("w@#e687qw6r", "ajdhs@abv.bg");

            }
            catch (InvalidPersonNameException a)
            {
                Console.WriteLine(a.Message);
            }
        }
    }
}
