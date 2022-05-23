namespace NavalVessels.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;

        private ICaptain captain;

        private double armorThickness;

        private double mainWeaponCaliber;

        private double speed;

        private readonly ICollection<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }

        }


        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            }
        }

        public double ArmorThickness 
        { 
            get => armorThickness;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                
                armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }

        public double Speed
        {
            get => speed;
            protected set => speed = value;
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();       
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots")
                .Append($" *Targets: {(targets.Any() ? string.Join(", ", targets) : "None")}");

            return sb.ToString();
        }
    }
}
