namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
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
            string sonarMode = this.SonarMode ? "ON" : "OFF";
            return base.ToString() + $"{Environment.NewLine} *Sonar mode: {sonarMode}";
        }
    }
}
