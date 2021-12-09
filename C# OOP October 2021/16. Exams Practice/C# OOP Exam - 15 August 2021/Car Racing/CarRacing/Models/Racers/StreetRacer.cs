using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string Default_RacingBehavior = "aggressive";

        private const int Default_DrivingExperience = 10;

        private const int DrivingExperience_Increasment = 5;


        public StreetRacer(string username, ICar car)
            : base(username, Default_RacingBehavior, Default_DrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += DrivingExperience_Increasment;
        }
    }
}
