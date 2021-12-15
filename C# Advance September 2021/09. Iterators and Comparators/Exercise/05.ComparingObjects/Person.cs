namespace _05.ComparingObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        private readonly string name;

        private readonly int age;

        private readonly string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            if (result == 0)
            {
                result = this.town.CompareTo(other.town);
            }

            return result;
        }
    }
}
