using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override double WeightMultiplier => 0.30;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Vegetable), typeof(Meat) }.AsReadOnly();

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
