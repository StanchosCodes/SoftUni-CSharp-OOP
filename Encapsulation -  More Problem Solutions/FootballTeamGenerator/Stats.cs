﻿using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException(String.Format(Messages.InvalidStat, nameof(this.Endurance)));
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException(String.Format(Messages.InvalidStat, nameof(this.Sprint)));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException(String.Format(Messages.InvalidStat, nameof(this.Dribble)));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException(String.Format(Messages.InvalidStat, nameof(this.Passing)));
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException(String.Format(Messages.InvalidStat, nameof(this.Shooting)));
                }

                this.shooting = value;
            }
        }

        public double GetAverageStat()
        {
            return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        }
    }
}
