namespace _07.MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;
    using Interfaces;
    using Enumerators;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps,
            ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>(repairs);
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString())                  
                  .AppendLine("Repairs:");

            foreach (var item in this.Repairs)
            {
                output.AppendLine($"  {item}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
