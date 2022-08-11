namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionApplier = 1.6;
        private const double FuelRefillDecrement = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {

        }

        protected override double FuelConsumtionIncrement
            => FuelConsumptionApplier;

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * FuelRefillDecrement);
        }
    }
}