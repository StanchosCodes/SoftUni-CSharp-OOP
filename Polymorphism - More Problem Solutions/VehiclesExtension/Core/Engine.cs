namespace VehiclesExtension.Core
{
    using System;
    using Models;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string cmdType = cmdArgs[0];
                string vehicle = cmdArgs[1];
                double amount = double.Parse(cmdArgs[2]);

                if (cmdType == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(this.car.Drive(amount));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(amount));
                    }
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(this.bus.Drive(amount));
                    }
                }
                else if (cmdType == "DriveEmpty")
                {
                    if (vehicle == "Bus")
                    {
                        this.bus.IsEmpty = true;
                        Console.WriteLine(this.bus.Drive(amount));
                        this.bus.IsEmpty = false;
                    }
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        this.car.Refuel(amount);
                    }
                    else if (vehicle == "Truck")
                    {
                        this.truck.Refuel(amount);
                    }
                    else if (vehicle == "Bus")
                    {
                        this.bus.Refuel(amount);
                    }
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}