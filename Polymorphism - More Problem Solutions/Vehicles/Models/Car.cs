namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumtionApplier = 0.9;
        public Car(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {

        }

        protected override double FuelConsumtionIncrement 
            => FuelConsumtionApplier;
    }
}
