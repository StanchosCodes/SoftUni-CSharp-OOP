namespace CarRacing.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Maps;
    using Models.Cars;
    using Repositories;
    using Models.Racers;
    using Utilities.Messages;
    using Models.Cars.Contracts;
    using Models.Maps.Contracts;
    using Models.Racers.Contracts;
    using System.Linq;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar newCar;

            if (type == "SuperCar")
            {
                newCar = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                newCar = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarType));
            }

            this.cars.Add(newCar);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer newRacer;
            ICar newCar = this.cars.FindBy(carVIN);

            if (newCar == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarCannotBeFound));
            }

            if (type == "ProfessionalRacer")
            {
                newRacer = new ProfessionalRacer(username, newCar);
            }
            else if (type == "StreetRacer")
            {
                newRacer = new StreetRacer(username, newCar);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerType));
            }

            this.racers.Add(newRacer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.Append($"{racer}{Environment.NewLine}");
            }

            return sb.ToString().Trim();
        }
    }
}
