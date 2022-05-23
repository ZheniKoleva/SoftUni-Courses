namespace Person
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age < 0)
            {
                return;
            }

            Person person = age > 15 
                ? new Person(name, age)
                : new Child(name, age);
            
            Console.WriteLine(person);
        }
    }
}