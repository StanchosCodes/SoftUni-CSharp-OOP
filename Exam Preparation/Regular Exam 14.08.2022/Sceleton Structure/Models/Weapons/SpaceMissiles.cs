namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities.Messages;

    public class SpaceMissiles : Weapon
    {
        private const double PriceValue = 8.75;

        public SpaceMissiles(int destructionLevel)
            : base(destructionLevel, PriceValue)
        {
        }
    }
}
