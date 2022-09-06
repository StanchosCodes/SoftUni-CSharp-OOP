namespace CarRacing.Models.Racers
{
    using System;
    using System.Text;

    using Contracts;
    using Cars.Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerName));
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get
            {
                return this.racingBehavior;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerBehavior));
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerDrivingExperience));
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get
            {
                return this.car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerCar));
                }

                this.car = value;
            }
        }

        public virtual void Race()
        {
            this.Car.Drive();
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
                // "{racer type}: {racer username}"
                // "--Driving behavior: {racingBehavior}"
                // "--Driving experience: {drivingExperience}"
                // "--Car: {carMake} {carModel} ({carVIN})"


            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.GetType().Name}: {this.Username}{Environment.NewLine}");
            sb.Append($"--Driving behavior: {this.RacingBehavior}{Environment.NewLine}");
            sb.Append($"--Driving experience: {this.DrivingExperience}{Environment.NewLine}");
            sb.Append($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");

            return sb.ToString().Trim();
        }
    }
}
