namespace _06.EqualityLogic
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        private readonly string name;

        private readonly int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode() => this.name.GetHashCode() ^ this.age.GetHashCode();
       
    }
}
