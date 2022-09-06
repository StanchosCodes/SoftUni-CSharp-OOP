namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities.Messages;

    using Contracts;
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get; private set; }

        public int DestructionLevel
        {
            get
            {
                return this.destructionLevel;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                if (value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooHighDestructionLevel));
                }

                this.destructionLevel = value;
            }
        }
    }
}
