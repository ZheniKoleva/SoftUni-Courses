using System.Linq;
using System.Collections.Generic;

using Gym.Repositories.Contracts;
using Gym.Models.Equipment.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly IList<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)models;

        public void Add(IEquipment model)
            => models.Add(model);


        public IEquipment FindByType(string type)
            => models.FirstOrDefault(x => x.GetType().Name == type);
       

        public bool Remove(IEquipment model)
            => models.Remove(model);
        
    }
}
