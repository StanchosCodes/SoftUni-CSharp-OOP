namespace PlanetWars.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();

        public IWeapon FindByName(string name)
        {
            return this.Models.FirstOrDefault(w => w.GetType().Name == name);
        }

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            IWeapon model = this.Models.FirstOrDefault(w => w.GetType().Name == name);

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
