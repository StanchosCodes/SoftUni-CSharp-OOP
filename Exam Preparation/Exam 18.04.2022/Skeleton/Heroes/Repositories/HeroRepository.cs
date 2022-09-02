namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.models.AsReadOnly();

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public bool Remove(IHero model)
        {
            if (this.models.Any(m => m.Name == model.Name))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }

        public IHero FindByName(string name)
        {
            IHero foundHero = this.models.FirstOrDefault(h => h.Name == name);

            return foundHero;
        }
    }
}
