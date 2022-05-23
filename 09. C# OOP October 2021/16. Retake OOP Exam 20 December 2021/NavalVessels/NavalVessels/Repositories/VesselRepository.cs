namespace NavalVessels.Repositories
{ 
    using System.Collections.Generic;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;


    public class VesselRepository : IRepository<IVessel>
    {
        private readonly IDictionary<string, IVessel> models;

        public VesselRepository()
        {
            models = new Dictionary<string,IVessel>();
        }
        
        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)models.Values;

        public void Add(IVessel model)
            => models.Add(model.Name, model);         

        public IVessel FindByName(string name)
            => models.ContainsKey(name) ? models[name] : null;      

        public bool Remove(IVessel model)
            => models.Remove(model.Name);       
    }
}
