using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> inhabiters = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];

                if (cmdArgs.Length == 2)
                {
                    string id = cmdArgs[1];

                    IIdentifiable newRobot = new Robot(name, id);
                    inhabiters.Add(newRobot);
                }
                else if (cmdArgs.Length == 3)
                {
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    IIdentifiable newCitizen = new Citizen(name, age, id);
                    inhabiters.Add(newCitizen);
                }
            }

            string fakeIdsLastDigits = Console.ReadLine();

            foreach (var inhabiter in inhabiters)
            {
                if (inhabiter.Id.EndsWith(fakeIdsLastDigits))
                {
                    Console.WriteLine(inhabiter.Id);
                }
            }
        }
    }
}
