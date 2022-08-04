using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 62);
            Car car = new Car(150, 60);
            Motorcycle motorcycle = new Motorcycle(40, 20);
            FamilyCar familyCar = new FamilyCar(90, 50);
            SportCar sportCar = new SportCar(180, 60);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(30, 25);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(40, 30);

            vehicle.Drive(4);
            car.Drive(5);
            motorcycle.Drive(8);
            familyCar.Drive(10);
            sportCar.Drive(5);
            crossMotorcycle.Drive(2);
            raceMotorcycle.Drive(2);

            Console.WriteLine(vehicle.Fuel);
            Console.WriteLine(vehicle.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(car.Fuel);
            Console.WriteLine(car.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(motorcycle.Fuel);
            Console.WriteLine(motorcycle.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(familyCar.Fuel);
            Console.WriteLine(familyCar.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(sportCar.Fuel);
            Console.WriteLine(sportCar.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(crossMotorcycle.Fuel);
            Console.WriteLine(crossMotorcycle.FuelConsumption);
            Console.WriteLine();

            Console.WriteLine(raceMotorcycle.Fuel);
            Console.WriteLine(raceMotorcycle.FuelConsumption);
        }
    }
}
