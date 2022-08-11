namespace Vehicles
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

            IFactory vehicleFactory = new Factory();

            Vehicle newCar = vehicleFactory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle newTruck = vehicleFactory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            IEngine engine = new Engine(newCar, newTruck);
            engine.Start();
        }
    }
}
