namespace Formula1.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities;
    using Contracts;
    using Repositories;
    using Models.Contracts;
    using Models.Pilots;
    using Models.Cars;
    using Formula1.Models.Races;
    using System.Linq;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            else
            {
                IPilot pilot = new Pilot(fullName);

                this.pilotRepository.Add(pilot);

                return String.Format(string.Format(OutputMessages.SuccessfullyCreatePilot, fullName));
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            if (this.formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            else
            {
                this.formulaOneCarRepository.Add(car);

                return string.Format(string.Format(OutputMessages.SuccessfullyCreateCar, type, model));
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);

            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            this.raceRepository.Add(race);

            return String.Format(string.Format(OutputMessages.SuccessfullyCreateRace, raceName));
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (this.pilotRepository.FindByName(pilotName) == null || this.pilotRepository.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else if (this.formulaOneCarRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            IFormulaOneCar car = this.formulaOneCarRepository.FindByName(carModel);

            this.pilotRepository.FindByName(pilotName).AddCar(car);
            this.formulaOneCarRepository.Remove(car);

            return String.Format(string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel));
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);

            if (this.raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (pilot == null || !pilot.CanRace || this.raceRepository.FindByName(raceName).Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            else
            {
                this.raceRepository.FindByName(raceName).Pilots.Add(pilot);

                return String.Format(string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName));
            }
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            else if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            orderedPilots[0].WinRace();
            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, orderedPilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, orderedPilots[1].FullName, raceName));
            sb.Append(string.Format(OutputMessages.PilotThirdPlace, orderedPilots[2].FullName, raceName));

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRace race in this.raceRepository.Models.Where(r => r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPilot pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
