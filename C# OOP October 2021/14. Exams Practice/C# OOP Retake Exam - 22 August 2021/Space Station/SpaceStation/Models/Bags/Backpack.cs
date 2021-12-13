using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Bags.Contracts;


namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly IList<string> items;

        public Backpack()
        {
            items = new List<string>();
        }

        public ICollection<string> Items => items;

        public override string ToString()
            => items.Any() ? string.Join(", ", items) : "none";
        
    }
}
