namespace _06.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleSet = new SortedSet<Person>();
            HashSet<Person> peopleHash = new HashSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                Person person = CreatePerson();
                peopleSet.Add(person);
                peopleHash.Add(person);
            }

            Console.WriteLine($"{peopleSet.Count}");
            Console.WriteLine($"{peopleHash.Count}");  
        }

        private static Person CreatePerson()
        {
            string[] personData = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = personData[0];
            int age = int.Parse(personData[1]);

            return new Person(name, age);
        }
    }
}
