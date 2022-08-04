namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;
        private const int MinGrams = 1;
        private const int MaxGrams = 200;

        private string flourType;
        private string bakingTechnique;
        private double grams;
        private double calories = 2;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTehnique = bakingTechnique;
            this.Grams = grams;
        }

        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                try
                {
                    if (value != "white" && value != "wholegrain")
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }

                    this.flourType = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }
                
            }
        }
        private string BakingTehnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                try
                {
                    if (value != "crispy" && value != "chewy" && value != "homemade")
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }

                    this.bakingTechnique = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid type of dough.");
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
                        throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                    }

                    this.grams = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                    Environment.Exit(0);
                }
            }
        }

        public double TotalCalories
        {
            get
            {
                double currFlourTypeValue = 0;

                switch (this.FlourType)
                {
                    case "white":
                        currFlourTypeValue = 1.5;
                        break;
                    case "wholegrain":
                        currFlourTypeValue = 1.0;
                        break;
                }

                double currTechniqueValue = 0;

                switch (this.BakingTehnique)
                {
                    case "crispy":
                        currTechniqueValue = 0.9;
                        break;
                    case "chewy":
                        currTechniqueValue = 1.1;
                        break;
                    case "homemade":
                        currTechniqueValue = 1.0;
                        break;
                }

                double totalCalories = this.grams * this.calories * currFlourTypeValue * currTechniqueValue;
                return Math.Round(totalCalories, 2);
            }
        }
    }
}
