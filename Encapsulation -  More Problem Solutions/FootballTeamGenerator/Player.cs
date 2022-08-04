using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(Messages.NameNullOrWhiteSpace, nameof(this.Name)));
                }

                this.name = value;
            }
        }

        public Stats Stats { get; private set; }
    }
}
