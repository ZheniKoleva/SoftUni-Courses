namespace _07.MilitaryElite.Models
{
    using System;
    using Interfaces;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine}Code Number: {CodeNumber}";        
    }
}
