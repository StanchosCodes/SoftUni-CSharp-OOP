namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumtionApplier = 0.9;
        public Car(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + FuelConsumtionApplier;
    }
}
