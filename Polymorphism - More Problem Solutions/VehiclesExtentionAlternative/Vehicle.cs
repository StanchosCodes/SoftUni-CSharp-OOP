using System;

namespace VehiclesExtentionAlternative
{
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

        public double FuelQuantity { get; private set; }

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

        public bool IsEmpty { get; set; }

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

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + amount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else if (this.FuelQuantity + amount <= this.TankCapacity)
            {
                this.FuelQuantity += amount;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
