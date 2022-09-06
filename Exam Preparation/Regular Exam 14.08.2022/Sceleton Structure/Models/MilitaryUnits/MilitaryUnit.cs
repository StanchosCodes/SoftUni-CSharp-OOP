namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int EnduranceLevelValue = 1;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = EnduranceLevelValue;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;

            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;

                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
        }
    }
}
