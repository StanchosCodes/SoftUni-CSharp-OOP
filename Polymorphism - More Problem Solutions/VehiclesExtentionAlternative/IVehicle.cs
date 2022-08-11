namespace VehiclesExtentionAlternative
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        double TankCapacity { get; }

        string Drive(double distance);
        void Refuel(double amount);
    }
}
