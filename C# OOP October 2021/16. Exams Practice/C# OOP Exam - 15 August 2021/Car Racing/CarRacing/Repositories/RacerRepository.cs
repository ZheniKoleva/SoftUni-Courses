using System;
using System.Collections.Generic;

using CarRacing.Utilities.Messages;
using CarRacing.Repositories.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly IDictionary<string,IRacer> models;

        public RacerRepository()
        {
            models = new Dictionary<string,IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)models.Values;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model.Username, model);
        }

        public IRacer FindBy(string property)
            => models.ContainsKey(property) ? models[property] : null;


        public bool Remove(IRacer model)
            => models.Remove(model.Username);
    }
}
