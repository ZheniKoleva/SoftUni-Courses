namespace Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
            => $"{base.ExplainSelf()}{Environment.NewLine}DJAAF";


    }
}