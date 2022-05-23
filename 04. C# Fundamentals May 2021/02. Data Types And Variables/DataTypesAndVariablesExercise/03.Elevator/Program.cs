using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int personCount = int.Parse(Console.ReadLine());
            int elevatorCapasity = int.Parse(Console.ReadLine());

            //int courses = (int)Math.Ceiling((double)personCount / elevatorCapasity);

            //Console.WriteLine(courses);
            Console.WriteLine(Math.Ceiling((double)personCount / elevatorCapasity));
        }
    }
}
