namespace _07.MilitaryElite.Models
{    
    using System;
    using Interfaces;
    using Enumerators;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}";
       
    }
}
