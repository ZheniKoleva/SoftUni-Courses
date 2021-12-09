using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string Default_RacingBehavior = "strict";

        private const int Default_DrivingExperience = 30;

        private const int DrivingExperience_Increasment = 10;


        public ProfessionalRacer(string username, ICar car) 
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
