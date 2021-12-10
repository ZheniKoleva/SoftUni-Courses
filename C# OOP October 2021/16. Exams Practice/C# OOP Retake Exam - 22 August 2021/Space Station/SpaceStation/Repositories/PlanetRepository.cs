using System.Collections.Generic;

using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Planets.Contracts;


namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IDictionary<string, IPlanet> models;

        public PlanetRepository()
        {
            models = new Dictionary<string, IPlanet>();
        }


        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)models.Values;


        public void Add(IPlanet model)
            => models.Add(model.Name, model);


        public IPlanet FindByName(string name)
            => models.ContainsKey(name) ? models[name] : null;


        public bool Remove(IPlanet model)
            => models.Remove(model.Name);

    }
}
