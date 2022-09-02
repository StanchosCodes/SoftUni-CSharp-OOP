namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Map;
    using Repositories;
    using Models.Heroes;
    using Models.Weapons;
    using Models.Contracts;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (this.heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (this.weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (this.heroes.FindByName(heroName).Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }


            IWeapon weapon = weapons.FindByName(weaponName);
            this.heroes.FindByName(heroName).AddWeapon(weapon);

            string weaponType = weapon.GetType().Name.ToLower();

            this.weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero newHero = null;

            if (type == "Knight")
            {
                newHero = new Knight(name, health, armour);
                this.heroes.Add(newHero);

                return $"Successfully added Sir {name} to the collection.";
            }
            else if (type == "Barbarian")
            {
                newHero = new Barbarian(name, health, armour);
                this.heroes.Add(newHero);

                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon newWeapon = null;

            if (type == "Claymore")
            {
                newWeapon = new Claymore(name, durability);
                this.weapons.Add(newWeapon);
            }
            else if (type == "Mace")
            {
                newWeapon = new Mace(name, durability);
                this.weapons.Add(newWeapon);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            // "{ hero type }: { hero name }
            // --Health: { hero health }
            // --Armour: { hero armour }
            // --Weapon: { weapon name }/ Unarmed

            StringBuilder sb = new StringBuilder();

            foreach (IHero hero in this.heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                string heroType = hero.GetType().Name;

                sb.AppendLine($"{heroType}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            List<IHero> readyHeroes = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();

            return map.Fight(readyHeroes);
         }
    }
}
