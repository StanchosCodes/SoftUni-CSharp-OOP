namespace Gym.Models.Equipment
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;

    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
