namespace PlanetWars.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.models.AsReadOnly();

        public IMilitaryUnit FindByName(string name)
        {
            return this.Models.FirstOrDefault(u => u.GetType().Name == name);
        }

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit model = this.Models.FirstOrDefault(u => u.GetType().Name == name);

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
