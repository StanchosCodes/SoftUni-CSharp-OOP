namespace VehiclesExtension
{
    using System;
    using Core;
    using Factories;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            IFactory vehicleFactory = new Factory();

            Vehicle newCar = vehicleFactory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle newTruck = vehicleFactory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle newBus = vehicleFactory.CreateVehicle(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            IEngine engine = new Engine(newCar, newTruck, newBus);
            engine.Start();
        }
    }
}
