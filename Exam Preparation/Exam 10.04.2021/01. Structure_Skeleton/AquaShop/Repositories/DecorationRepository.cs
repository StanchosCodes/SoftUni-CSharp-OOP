namespace AquaShop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Decorations.Contracts;
    using Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration foundDecor = this.models.FirstOrDefault(m => m.GetType().Name == type);

            return foundDecor;
        }
    }
}
