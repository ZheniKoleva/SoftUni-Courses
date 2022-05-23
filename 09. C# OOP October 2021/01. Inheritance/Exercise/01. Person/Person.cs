namespace Person
{
    using System;

    public class Person
    {
        private const int MIN_AGE = 0;

        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual int Age 
        {
            get => this.age;           
            set
            {
                if (value < MIN_AGE)
                {
                    throw new ArgumentException();
                }
               
                this.age = value;
            }
        }

        public override string ToString() 
            => $"Name: {this.Name}, Age: {this.Age}";
    }
}
