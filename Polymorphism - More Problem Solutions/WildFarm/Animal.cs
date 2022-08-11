using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public abstract class Animal
    {
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }


        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public void Eat(Food food)
        {
            if (this.PreferredFoods.Contains(food.GetType()))
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * this.WeightMultiplier;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
