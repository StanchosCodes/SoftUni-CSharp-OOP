namespace VehiclesExtension.Factories
{
    using System;
    using Models;

    public class Factory : IFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
