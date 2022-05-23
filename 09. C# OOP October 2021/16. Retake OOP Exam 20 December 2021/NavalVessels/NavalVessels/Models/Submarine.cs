namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double Initial_ArmorThickness = 200;

        private const double WeaponCaliber_Change = 40;

        private const double Speed_Change = 4;

        private bool submergeMode;


        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, Initial_ArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { 
            get => submergeMode;
            private set => submergeMode = value; 
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < Initial_ArmorThickness)
            {
                ArmorThickness = Initial_ArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == true)
            {                
                MainWeaponCaliber -= WeaponCaliber_Change;
                Speed += Speed_Change;
            }
            else
            {                
                MainWeaponCaliber += WeaponCaliber_Change;
                Speed -= Speed_Change;
            }

            SubmergeMode = !SubmergeMode;
        }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine} *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
       
    }
}
