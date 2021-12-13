using System;
using System.Collections.Generic;

using CarRacing.Utilities.Messages;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string,ICar> models;

        public CarRepository()
        {
            models = new Dictionary<string,ICar>();
        }

        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models.Values;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model.VIN, model);
        }

        public ICar FindBy(string property)
            => models.ContainsKey(property) ? models[property] : null;
      

        public bool Remove(ICar model)
            => models.Remove(model.VIN);
       
    }
}
