namespace Bakery.Models.Tables
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Drinks.Contracts;
    using Utilities.Messages;
    using BakedFoods.Contracts;

    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.IsReserved = false;
            this.numberOfPeople = 0;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => this.foodOrders;
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders;

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTableCapacity));
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfPeople));
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            return this.FoodOrders.Sum(f => f.Price) + this.DrinkOrders.Sum(d => d.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            // "Table: {table number}"
            // "Type: {table type}"
            // "Capacity: {table capacity}"
            // "Price per Person: {price per person for the current table}"

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.Append($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}