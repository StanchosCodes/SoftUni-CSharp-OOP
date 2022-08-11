using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        protected override double WeightMultiplier => 0.10;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
