using System.Collections.Generic;

using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;


namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly IDictionary<string, IEgg> models;

        public EggRepository()
        {
            models = new Dictionary<string, IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
            => (IReadOnlyCollection<IEgg>)models.Values;

        public void Add(IEgg egg)
            => models.Add(egg.Name, egg);

        public IEgg FindByName(string name)
            => models.ContainsKey(name) ? models[name] : null;

        public bool Remove(IEgg egg)
            => models.Remove(egg.Name);
    }
}
