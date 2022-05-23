namespace _07.MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;
    using Interfaces;
    using Enumerators;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps,
            ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>(missions);
        }

        public IReadOnlyCollection<IMission> Missions { get;  }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .AppendLine("Missions:");

            foreach (var item in this.Missions)
            {
                output.AppendLine($"  {item}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
