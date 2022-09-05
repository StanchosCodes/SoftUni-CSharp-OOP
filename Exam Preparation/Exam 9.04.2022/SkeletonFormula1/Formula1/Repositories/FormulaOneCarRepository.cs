namespace Formula1.Repositories
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.models.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.models.FirstOrDefault(c => c.Model == name);
        }
    }
}
