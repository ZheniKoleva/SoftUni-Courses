using System.Linq;

using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
            => Models.FirstOrDefault(x => x.Model == name);       
    }
}
