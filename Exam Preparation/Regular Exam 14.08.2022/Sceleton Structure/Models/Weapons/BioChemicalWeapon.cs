namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities.Messages;

    public class BioChemicalWeapon : Weapon
    {
        private const double PriceValue = 3.2;

        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, PriceValue)
        {
        }
    }
}
