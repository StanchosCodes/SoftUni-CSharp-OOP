namespace PlanetWars.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Utilities.Messages;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using System.Linq;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.Weapons;

    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (this.planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            this.planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit;

            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (this.planets.FindByName(planetName).Army.FirstOrDefault(u => u.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            this.planets.FindByName(planetName).Spend(unit.Cost);
            this.planets.FindByName(planetName).AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
           if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (this.planets.FindByName(planetName).Weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            this.planets.FindByName(planetName).Spend(weapon.Price);
            this.planets.FindByName(planetName).AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (this.planets.FindByName(planetName).Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            this.planets.FindByName(planetName).Spend(1.25);
            this.planets.FindByName(planetName).TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            double planetOnePower = this.planets.FindByName(planetOne).MilitaryPower;
            double planetTwoPower = this.planets.FindByName(planetTwo).MilitaryPower;

            bool IsPlanetOneNuclear = this.planets.FindByName(planetOne).Weapons.FirstOrDefault(w => w.GetType() == typeof(NuclearWeapon)) != null ? true : false;

            bool IsPlanetTwoNuclear = this.planets.FindByName(planetTwo).Weapons.FirstOrDefault(w => w.GetType() == typeof(NuclearWeapon)) != null ? true : false;

            if (planetOnePower == planetTwoPower)
            {
                if (IsPlanetOneNuclear && IsPlanetTwoNuclear || !IsPlanetOneNuclear && !IsPlanetTwoNuclear)
                {
                    this.planets.FindByName(planetOne).Spend(this.planets.FindByName(planetOne).Budget / 2);
                    this.planets.FindByName(planetTwo).Spend(this.planets.FindByName(planetTwo).Budget / 2);

                    return string.Format(OutputMessages.NoWinner);
                }
                else if (IsPlanetOneNuclear && !IsPlanetTwoNuclear)
                {
                    this.planets.FindByName(planetOne).Spend(this.planets.FindByName(planetOne).Budget / 2);
                    this.planets.FindByName(planetOne).Profit(this.planets.FindByName(planetTwo).Budget / 2);

                    double totalProfit = this.planets.FindByName(planetTwo).Army.Sum(u => u.Cost) + this.planets.FindByName(planetTwo).Weapons.Sum(w => w.Price);

                    this.planets.FindByName(planetOne).Profit(totalProfit);

                    this.planets.RemoveItem(planetTwo);

                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    this.planets.FindByName(planetTwo).Spend(this.planets.FindByName(planetTwo).Budget / 2);
                    this.planets.FindByName(planetTwo).Profit(this.planets.FindByName(planetOne).Budget / 2);

                    double totalProfit = this.planets.FindByName(planetOne).Army.Sum(u => u.Cost) + this.planets.FindByName(planetOne).Weapons.Sum(w => w.Price);

                    this.planets.FindByName(planetTwo).Profit(totalProfit);

                    this.planets.RemoveItem(planetOne);

                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }
            else if (planetOnePower > planetTwoPower)
            {
                this.planets.FindByName(planetOne).Spend(this.planets.FindByName(planetOne).Budget / 2);
                this.planets.FindByName(planetOne).Profit(this.planets.FindByName(planetTwo).Budget / 2);

                double totalProfit = this.planets.FindByName(planetTwo).Army.Sum(u => u.Cost) + this.planets.FindByName(planetTwo).Weapons.Sum(w => w.Price);

                this.planets.FindByName(planetOne).Profit(totalProfit);

                this.planets.RemoveItem(planetTwo);

                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                this.planets.FindByName(planetTwo).Spend(this.planets.FindByName(planetTwo).Budget / 2);
                this.planets.FindByName(planetTwo).Profit(this.planets.FindByName(planetOne).Budget / 2);

                double totalProfit = this.planets.FindByName(planetOne).Army.Sum(u => u.Cost) + this.planets.FindByName(planetOne).Weapons.Sum(w => w.Price);

                this.planets.FindByName(planetTwo).Profit(totalProfit);

                this.planets.RemoveItem(planetOne);

                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        } 
    }
}
