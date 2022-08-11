using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override double WeightMultiplier => 1.00;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
