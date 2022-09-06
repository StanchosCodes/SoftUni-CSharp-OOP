namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FuelAvailableValue = 65;
        private const double FuelConsumptionPerRaceValue = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableValue, FuelConsumptionPerRaceValue)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)(HorsePower * 0.97);
        }
    }
}
