namespace CarRacing.Models.Maps
{
    using Contracts;
    using Utilities.Messages;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                double racerOneMultiplier = 0;
                double racerTwoMultiplier = 0;

                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneMultiplier = 1.2;
                }
                else
                {
                    racerOneMultiplier = 1.1;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoMultiplier = 1.2;
                }
                else
                {
                    racerTwoMultiplier = 1.1;
                }

                double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;
                double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;

                racerOne.Race();
                racerTwo.Race();

                if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }
        }
    }
}
