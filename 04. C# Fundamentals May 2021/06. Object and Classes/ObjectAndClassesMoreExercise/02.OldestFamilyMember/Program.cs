using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());

            Family members = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] memberData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = memberData[0];
                int age = int.Parse(memberData[1]);

                Person current = new Person(name, age);

                members.AddMember(current);
            }

            Person oldest = members.GetOldestMember();
            Console.WriteLine(oldest);
        }
    }

    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    public class Family
    {
        private List<Person> relatives;

        public Family()
        {
            FamilyList = new List<Person>();
        }

        public Family(Person familyMember)
        {
            FamilyList = new List<Person>() { familyMember };
        }

        public List<Person> FamilyList { get; set; }

        public void AddMember(Person member)
        {
            FamilyList.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = FamilyList
                .OrderByDescending(p => p.Age)
                .First();

            return oldest;
        }
    }
}
