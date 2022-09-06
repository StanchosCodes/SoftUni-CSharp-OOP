namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string RacingBehaviourValue = "strict";
        private const int DrivingXPValue = 30;

        public ProfessionalRacer(string username, ICar car)
            : base(username, RacingBehaviourValue, DrivingXPValue, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
