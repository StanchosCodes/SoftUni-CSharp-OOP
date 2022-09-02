namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();

        public void Add(IWeapon model)
        {
            this.models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            if (this.models.Any(m => m.Name == model.Name))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }

        public IWeapon FindByName(string name)
        {
            IWeapon foundWeapon = this.models.FirstOrDefault(w => w.Name == name);

            return foundWeapon;
        }
    }
}
