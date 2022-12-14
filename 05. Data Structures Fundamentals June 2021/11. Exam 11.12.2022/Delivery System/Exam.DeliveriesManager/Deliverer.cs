using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public class Deliverer
    {
        public Deliverer(string id, string name)
        {
            Id = id;
            Name = name;
            packages = new HashSet<Package>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Package> packages { get; set; }
    }
}
