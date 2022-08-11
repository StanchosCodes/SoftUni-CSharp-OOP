namespace VehiclesExtension.Factories
{
    using Models;

    public interface IFactory
    {
        Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}