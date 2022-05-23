namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                Person person = CreatePerson(line);
                people.Add(person);
            }

            int personIndx = int.Parse(Console.ReadLine()) - 1;

            int matches = people.Where(x => x.CompareTo(people[personIndx]) == 0).Count();
            int notEqual = people.Count - matches;

            Console.WriteLine(matches == 1 ? "No matches" : $"{matches} {notEqual} {people.Count}");
        }

        private static Person CreatePerson(string line)
        {
            string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            int age = int.Parse(data[1]);
            string town = data[2];

            return new Person(name, age, town);
        }
    }
}
