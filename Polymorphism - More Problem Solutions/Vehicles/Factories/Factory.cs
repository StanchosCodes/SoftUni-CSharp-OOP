namespace Vehicles.Factories
{
    using System;
    using Models;

    public class Factory : IFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
