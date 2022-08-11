using System;
using System.Linq;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAlive> aliveInhabiters = new List<IAlive>();
            List<IIdentifiable> robots = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArgs[0];

                if (type == "Pet")
                {
                    string name = cmdArgs[1];
                    string birthdate = cmdArgs[2];

                    IAlive newPet = new Pet(name, birthdate);
                    aliveInhabiters.Add(newPet);
                }
                else if (type == "Citizen")
                {
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];

                    IAlive newCitizen = new Citizen(name, age, id, birthdate);
                    aliveInhabiters.Add(newCitizen);
                }
                else if (type == "Robot")
                {
                    string model = cmdArgs[1];
                    string id = cmdArgs[2];

                    IIdentifiable newRobot = new Robot(model, id);
                    robots.Add(newRobot);
                }
            }

            string yearToSearch = Console.ReadLine();

            foreach (var inhabiter in aliveInhabiters)
            {
                if (inhabiter.Birthdate.EndsWith(yearToSearch))
                {
                    Console.WriteLine(inhabiter.Birthdate);
                }
            }
        }
    }
}
