
namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products = new List<Product>();

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = products;
        }

        public List<Product> Products { get; set; }

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

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("The given argument for money is negative");
                    }

                    this.money = value;
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
            if (this.products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", products)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
