using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        protected override double WeightMultiplier => 0.40;

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();


        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
