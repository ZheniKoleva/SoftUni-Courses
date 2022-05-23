using System.Collections.Generic;

using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;


namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IDictionary<string, IAstronaut> models;

        public AstronautRepository()
        {
            models = new Dictionary<string, IAstronaut>();
        }


        public IReadOnlyCollection<IAstronaut> Models 
            => (IReadOnlyCollection<IAstronaut>)models.Values;


        public void Add(IAstronaut model)
            => models.Add(model.Name, model);
       

        public IAstronaut FindByName(string name)
            => models.ContainsKey(name) ? models[name] : null;
        

        public bool Remove(IAstronaut model)
            => models.Remove(model.Name);        
       
    }
}
