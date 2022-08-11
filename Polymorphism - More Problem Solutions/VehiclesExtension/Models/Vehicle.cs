namespace VehiclesExtension.Models
{
    using System;
    using Interfaces;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity || fuelQuantity < 0 ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; set; }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    this.tankCapacity = 0;
                }

                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + fuelAmount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else if (this.FuelQuantity + fuelAmount <= this.TankCapacity)
            {
                this.FuelQuantity += fuelAmount;
            }
        }

        public bool IsEmpty { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
