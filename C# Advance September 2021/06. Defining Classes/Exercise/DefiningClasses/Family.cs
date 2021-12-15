namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }

        public List<Person> Members { get; set; }

        public void AddMember(Person person) => Members.Add(person);

        public Person GetOldestMember()
            => Members.OrderByDescending(x => x.Age).FirstOrDefault();
    }
}

