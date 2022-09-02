namespace Heroes.Models.Heroes
{
    using System;

    using Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
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
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get
            {
                return this.armour;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get
            {
                return this.weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon) // => this.Weapon = weapon; -> it can be written that way too
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            if (this.Weapon == null)
            {
                this.Weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            int leftoverPoints = this.Armour - points;

            if (leftoverPoints < 0)
            {
                leftoverPoints = points - this.Armour;
                this.Armour = 0;

                if (this.Health - leftoverPoints <= 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= leftoverPoints;
                }
            }
            else
            {
                this.Armour -= points;
            }

        }
    }
}
