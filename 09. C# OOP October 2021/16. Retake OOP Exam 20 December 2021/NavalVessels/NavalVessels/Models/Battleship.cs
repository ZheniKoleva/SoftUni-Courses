namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double Initial_ArmorThickness = 300;

        private const double WeaponCaliber_Change = 40;

        private const double Speed_Change = 5;

        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, Initial_ArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode 
        { 
            get => sonarMode;
            private set => sonarMode = value; 
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < Initial_ArmorThickness)
            {
                ArmorThickness = Initial_ArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {                
                MainWeaponCaliber -= WeaponCaliber_Change;
                Speed += Speed_Change;
            }
            else
            {                
                MainWeaponCaliber += WeaponCaliber_Change;
                Speed -= Speed_Change;
            }

            SonarMode = !SonarMode;
        }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine} *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
      
    }
}
