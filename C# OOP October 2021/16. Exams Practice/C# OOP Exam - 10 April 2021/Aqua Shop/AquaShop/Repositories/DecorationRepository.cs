using System.Linq;
using System.Collections.Generic;

using AquaShop.Repositories.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private IList<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models 
            => (IReadOnlyCollection<IDecoration>)this.models;


        public void Add(IDecoration model)
            => this.models.Add(model);


        public IDecoration FindByType(string type)
            => this.models.FirstOrDefault(x => x.GetType().Name == type);      
        

        public bool Remove(IDecoration model)
            => this.models.Remove(model);
       
    }
}
