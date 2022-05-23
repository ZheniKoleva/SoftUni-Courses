namespace NavalVessels.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Captain : ICaptain
    {
        private const int CombatExperience_Increasment = 10;

        private string fullName;

        private int combatExperience;

        private readonly ICollection<IVessel> vessels; 

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }


        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(FullName), ExceptionMessages.InvalidCaptainName);
                }

                fullName = value;
            }

        }

        public int CombatExperience 
        { 
            get => combatExperience; 
            private set => combatExperience = value; 
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }            

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
            => CombatExperience += CombatExperience_Increasment;
        

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            foreach (var vessel in vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
