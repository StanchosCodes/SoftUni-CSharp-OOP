namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public override string ToString()
        {
            string sonarMode = this.SubmergeMode ? "ON" : "OFF";
            return base.ToString() + $"{Environment.NewLine} *Submerge mode: {sonarMode}";
        }
    }
}
