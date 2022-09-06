namespace Gym.Models.Gyms
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Athletes.Contracts;
    using Equipment.Contracts;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public double EquipmentWeight => this.Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity < this.Athletes.Count + 1)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughSize));
            }

            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            // "{gymName} is a {gymType}:
            // Athletes: { athleteName1}, { athleteName2}, { athleteName3} (…) / No athletes
            // Equipment total count: { equipmentCount}
            // Equipment total weight: { equipmentWeight} grams"

            StringBuilder sb = new StringBuilder();

            string athletes = this.Athletes.Count == 0 ? "No athletes" : $"{string.Join(", ", this.Athletes.Select(a => a.FullName))}";


            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletes}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.Append($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
    }
}
