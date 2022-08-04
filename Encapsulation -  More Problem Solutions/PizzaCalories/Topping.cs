namespace PizzaCalories
{
    using System;
    using System.Linq;

    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        private const int MinGrams = 1;
        private const int MaxGrams = 50;

        private string type;
        private double grams;
        private double calories = 2;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                try
                {
                    if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                    {
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                    }

                    this.type = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Cannot place {char.ToUpper(value[0]) + value.Substring(1)} on top of your pizza.");
                    Environment.Exit(0);
                }
            }
        }

        private double Grams
        {
            get
            {
                return this.grams;
            }
            set
            {
                try
                {
                    if (value < MinGrams || value > MaxGrams)
                    {
                        throw new ArgumentException($"{this.Type} weight should be in the range [{MinGrams}..{MaxGrams}].");
                    }

                    this.grams = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{char.ToUpper(this.Type[0]) + this.Type.Substring(1)} weight should be in the range [{MinGrams}..{MaxGrams}].");
                    Environment.Exit(0);
                }
                
            }
        }

        public double TotalCalories
        {
            get
            {
                double currTypeValue = 0;

                switch (this.Type)
                {
                    case "meat":
                        currTypeValue = 1.2;
                        break;
                    case "veggies":
                        currTypeValue = 0.8;
                        break;
                    case "cheese":
                        currTypeValue = 1.1;
                        break;
                    case "sauce":
                        currTypeValue = 0.9;
                        break;
                }

                double totalCalories = this.Grams * this.calories * currTypeValue;

                return Math.Round(totalCalories, 2);
            }
        }
    }
}
