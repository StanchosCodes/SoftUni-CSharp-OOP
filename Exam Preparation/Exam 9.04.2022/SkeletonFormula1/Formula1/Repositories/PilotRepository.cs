namespace Formula1.Repositories
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;
    using System.Linq;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models.AsReadOnly();

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.FullName == name);
        }
    }
}
