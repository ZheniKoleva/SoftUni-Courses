using System.Collections.Generic;

using EasterRaces.Repositories.Contracts;


namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> Models { get; private set; }

        protected Repository()
        {
            Models = new HashSet<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return Models.Remove(model);
        }
    }
}
