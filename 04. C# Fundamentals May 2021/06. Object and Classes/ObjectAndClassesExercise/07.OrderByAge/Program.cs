using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] personData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                peoples.Add(new Person(name, id, age));

                line = Console.ReadLine();
            }

            peoples = peoples.OrderBy(p => p.Age).ToList();

            //Console.WriteLine(string.Join(Environment.NewLine, peoples));

            foreach (Person people in peoples)
            {
                Console.WriteLine(people);
            }
        }
    }

    public class Person
    {
        private string name;

        private string id;

        private int age;

        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
