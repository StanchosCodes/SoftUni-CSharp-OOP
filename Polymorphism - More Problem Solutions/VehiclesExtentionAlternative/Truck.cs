namespace VehiclesExtentionAlternative
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionApplier = 1.6;
        private const double FuelRefillDecrement = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + FuelConsumptionApplier;

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount + this.FuelQuantity > this.TankCapacity)
            {
                base.Refuel(fuelAmount);
            }
            else
            {
                base.Refuel(fuelAmount * FuelRefillDecrement);
            }
        }
    }
}
