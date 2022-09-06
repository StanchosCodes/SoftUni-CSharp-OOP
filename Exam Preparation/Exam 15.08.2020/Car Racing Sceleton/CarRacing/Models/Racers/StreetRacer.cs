namespace CarRacing.Models.Racers
{
    using Cars.Contracts;
    public class StreetRacer : Racer
    {
        private const string RacingBehaviourValue = "aggressive";
        private const int DrivingXPValue = 10;

        public StreetRacer(string username, ICar car)
            : base(username, RacingBehaviourValue, DrivingXPValue, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
