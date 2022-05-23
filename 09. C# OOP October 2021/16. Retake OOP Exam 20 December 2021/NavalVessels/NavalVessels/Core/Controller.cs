namespace NavalVessels.Core
{
    using System.Collections.Generic;

    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Utilities.Messages;

    public class Controller : IController
    {
        private readonly VesselRepository vessels;

        private readonly IDictionary<string, ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new Dictionary<string, ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.ContainsKey(selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            ICaptain captain = captains[selectedCaptainName];

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, captain.FullName, vessel.Name);
        }

     

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel defender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel,
                defender.Name, attacker.Name, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.ContainsKey(captainFullName) ? captains[captainFullName] : null;

            if (captain != null)
            {
                return captain.Report();
            }

            return null;
        }

        public string HireCaptain(string fullName)
        {
            if (captains.ContainsKey(fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = CreateCaptain(fullName);
            captains.Add(captain.FullName, captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, captain.FullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselType != nameof(Battleship) && vesselType != nameof(Submarine))
            {
                return OutputMessages.InvalidVesselType;
            }            

            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);            
            }

            IVessel vessel = CreateVessel(name, vesselType, mainWeaponCaliber, speed);

            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, 
                vessel.GetType().Name, vessel.Name, vessel.MainWeaponCaliber, vessel.Speed);

        }

      
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vessel.Name);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                Battleship vesselAsBattle = vessel as Battleship;
                vesselAsBattle.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            if (vessel.GetType().Name == nameof(Submarine))
            {                
                Submarine vesselAsSubmarine = vessel as Submarine;
                vesselAsSubmarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return null;
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel != null)
            {
                return vessel.ToString();
            }

            return null;
        }

        private IVessel CreateVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vesselType switch
            {
                nameof(Battleship) => new Battleship(name, mainWeaponCaliber, speed),
                nameof(Submarine) => new Submarine(name, mainWeaponCaliber, speed),
            };

            return vessel;
        }

        private ICaptain CreateCaptain(string selectedCaptainName)
        {
            ICaptain captain = new Captain(selectedCaptainName);

            return captain;
        }
    }
}
