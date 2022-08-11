namespace VehiclesExtentionAlternative
{
    public class Bus : Vehicle
    {
        public const double FuelConsumptionApplier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {

        }

        public override double FuelConsumption
            => base.IsEmpty ? base.FuelConsumption : base.FuelConsumption + FuelConsumptionApplier;
    }
}
