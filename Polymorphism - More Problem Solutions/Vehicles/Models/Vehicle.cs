namespace Vehicles.Models
{
    using Interfaces;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        private Vehicle()
        {
            this.FuelConsumtionIncrement = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumtion)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value + this.FuelConsumtionIncrement;
            }
        }

        protected virtual double FuelConsumtionIncrement { get; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.fuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.fuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
