namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Models.Racers.Contracts;

    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAddRacerRepository));
            }

            this.models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return this.Models.FirstOrDefault(r => r.Username == property);
        }
    }
}
