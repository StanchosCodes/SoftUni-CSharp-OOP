namespace Formula1.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(r => r.RaceName == name);
        }
    }
}