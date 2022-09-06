namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Gyms;
    using Repositories;
    using Models.Athletes;
    using Models.Equipment;
    using Utilities.Messages;
    using Models.Gyms.Contracts;
    using Models.Athletes.Contracts;
    using Models.Equipment.Contracts;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }

            this.gyms.Add(gym);

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currEquipment;

            if (equipmentType == "BoxingGloves")
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                currEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEquipmentType));
            }

            this.equipment.Add(currEquipment);

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currEquipment = this.equipment.FindByType(equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            this.gyms.First(g => g.Name == gymName).AddEquipment(currEquipment);
            this.equipment.Remove(currEquipment);

            return string.Format(string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName));
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currAthlete;

            string gymType = this.gyms.First(g => g.Name == gymName).GetType().Name;

            if (athleteType == "Boxer")
            {
                currAthlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gymType == "BoxingGym")
                {
                    this.gyms.First(g => g.Name == gymName).AddAthlete(currAthlete);
                }
                else
                {
                    throw new InvalidOperationException(String.Format(OutputMessages.InappropriateGym));
                }
            }
            else if (athleteType == "Weightlifter")
            {
                currAthlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gymType == "WeightliftingGym")
                {
                    this.gyms.First(g => g.Name == gymName).AddAthlete(currAthlete);
                }
                else
                {
                    throw new InvalidOperationException(String.Format(OutputMessages.InappropriateGym));
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAthleteType));
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            foreach (IAthlete athlete in this.gyms.First(g => g.Name == gymName).Athletes)
            {
                athlete.Exercise();
            }

            int athletesCount = this.gyms.First(g => g.Name == gymName).Athletes.Count;

            return String.Format(OutputMessages.AthleteExercise, athletesCount);
        }

        public string EquipmentWeight(string gymName)
        {
            double currEquipmentWeight = this.gyms.First(g => g.Name == gymName).EquipmentWeight;

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, currEquipmentWeight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
