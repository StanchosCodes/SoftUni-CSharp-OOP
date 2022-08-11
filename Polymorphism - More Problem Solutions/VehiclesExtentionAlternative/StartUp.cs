using System;

namespace VehiclesExtentionAlternative
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

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
                        Console.WriteLine(car.Drive(amount));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(bus.Drive(amount));
                    }
                }
                else if (cmdType == "DriveEmpty")
                {
                    if (vehicle == "Bus")
                    {
                        bus.IsEmpty = true;
                        Console.WriteLine(bus.Drive(amount));
                        bus.IsEmpty = false;
                    }
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(amount);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
