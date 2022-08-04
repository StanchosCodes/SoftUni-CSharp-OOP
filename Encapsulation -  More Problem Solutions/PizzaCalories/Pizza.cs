using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinToppings = 0;
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;
        private Topping topping;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                try
                {
                    if (string.IsNullOrEmpty(value)  || value.Length < 1 || value.Length > 15)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }

                    this.name = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
            }
        }

        public List<Topping> Toppings { get; set; }
        public int Count 
        {
            get
            {
                return this.Toppings.Count;
            }
        }

        public Dough Dough 
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }

        private Topping Topping 
        {
            get
            {
                return this.topping;
            }
            set
            {
                this.topping = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            try
            {
                if (this.toppings.Count < MinToppings || this.toppings.Count + 1 > MaxToppings)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
                }

                this.toppings.Add(topping);
            }
            catch (Exception)
            {
                Console.WriteLine($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
                Environment.Exit(0);
            }
        }

        public double TotalCalories
        {
            get
            {
                double topingsCalories = this.toppings.Sum(t => t.TotalCalories);
                double doughCalories = this.Dough.TotalCalories;

                double totalCalories = topingsCalories + doughCalories;
                return totalCalories;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
