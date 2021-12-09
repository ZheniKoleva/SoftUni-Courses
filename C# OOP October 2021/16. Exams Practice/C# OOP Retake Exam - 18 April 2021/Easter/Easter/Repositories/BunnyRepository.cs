using System.Collections.Generic;

using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly IDictionary<string, IBunny> models;

        public BunnyRepository()
        {
            models = new Dictionary<string, IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models 
            => (IReadOnlyCollection<IBunny>)models.Values;

        public void Add(IBunny model) 
            => models.Add(model.Name, model);

        public IBunny FindByName(string name)
            => models.ContainsKey(name) ? models[name] : null;

        public bool Remove(IBunny model)
            => models.Remove(model.Name);
       
    }
}
