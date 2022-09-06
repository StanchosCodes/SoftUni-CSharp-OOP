namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvailableValue = 80;
        private const double FuelConsumptionPerRaceValue = 10;

        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableValue, FuelConsumptionPerRaceValue)
        {
        }
    }
}
