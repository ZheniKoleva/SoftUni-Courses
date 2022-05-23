namespace Person
{
    using System;

    public class Child : Person
    {
        //private const int MAX_AGE = 15;

        //private int age;

        public Child(string name, int age)
            : base(name, age)
        {           
        }

        //public override int Age
        //{
        //    get => this.age;
        //    set
        //    {
        //        if (value > MAX_AGE)
        //        {
        //            throw new ArgumentException();
        //        }                
                
        //        this.age = value;
        //    }
        //}

    }
}
 