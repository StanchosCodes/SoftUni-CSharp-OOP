using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;
        //readonly makes it immutable, can be set only on initialization, after initialization you cannot change the reference anymore
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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
                    throw new ArgumentException(Messages.NameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        //Get-only, auto-calculated property (no setting, calculated on another properties value (on Stats() value, which is every Player() Average score)
        public int Rating
        {
            get
            {
                if (this.players.Any())
                {
                    return (int)Math.Round(this.players.Average(p => p.Stats.GetAverageStat()), 0);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void PlayerToRemove(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);

            // Checking if the player exists in the team;
            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(Messages.NotExistingPlayer, playerName, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
