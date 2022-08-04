namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("The given argument for name is empty");
                    }

                    this.name = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }

            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("The given argument for money is negative");
                    }

                    this.cost = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }

            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
