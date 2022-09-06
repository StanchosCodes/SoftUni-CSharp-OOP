namespace PlanetWars.Models.Planets
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Repositories;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }

                this.budget = value;
            }
        }
        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach(IMilitaryUnit unit in this.army.Models)
            {
                unit.IncreaseEndurance();
            }    
        }

        public void Spend(double amount)
        {
            if (this.Budget - amount < 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            // "Planet: {planetName}
            // --Budget: { budgetAmount} billion QUID
            // --Forces: { militaryUnitName1}, { militaryUnitName2}, { militaryUnitName3} (…) / No units
            // --Combat equipment: { weaponName1}, { weaponName2}, { weaponName3} (…) / No weapons
            // --Military Power: { militaryPower}

            string forces = this.Army.Count > 0 ? $"{string.Join(", ", this.Army.Select(u => u.GetType().Name))}" : "No units";
            string weapons = this.Weapons.Count > 0 ? $"{string.Join(", ", this.Weapons.Select(w => w.GetType().Name))}" : "No weapons";

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forces}");
            sb.AppendLine($"--Combat equipment: {weapons}");
            sb.Append($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        private double CalculateMilitaryPower()
        {
            double unitsSum = (double)this.Army.Sum(u => u.EnduranceLevel);
            double weaponsSum = (double)this.Weapons.Sum(w => w.DestructionLevel);
            double sum = unitsSum + weaponsSum;

            IMilitaryUnit anonymousImpactUnit = this.Army.FirstOrDefault(u => u.GetType() == typeof(AnonymousImpactUnit));

            if (anonymousImpactUnit != null)
            {
                sum += sum * 0.30;
            }

            IWeapon nuclearWeapon = this.Weapons.FirstOrDefault(w => w.GetType() == typeof(NuclearWeapon));

            if (nuclearWeapon != null)
            {
                sum += sum * 0.45;
            }
            return Math.Round(sum, 3);
        }
    }
}
