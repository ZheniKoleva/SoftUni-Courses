namespace _07.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, 
            ICollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>(privates);
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .AppendLine("Privates:");

            foreach (var item in this.Privates)
            {
                output.AppendLine($"  {item}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
