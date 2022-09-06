namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities.Messages;

    public class NuclearWeapon : Weapon
    {
        private const double PriceValue = 15;

        public NuclearWeapon(int destructionLevel)
            : base(destructionLevel, PriceValue)
        {
        }
    }
}
