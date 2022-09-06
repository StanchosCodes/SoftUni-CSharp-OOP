namespace PlanetWars.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public IPlanet FindByName(string name)
        {
            return this.Models.FirstOrDefault(p => p.Name == name);
        }

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            IPlanet model = this.Models.FirstOrDefault(p => p.Name == name);

            if (model == null)
            {
                return false;
            }
            else
            {
                this.models.Remove(model);
                return true;
            }
        }
    }
}
