namespace Gym.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this.models.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}
