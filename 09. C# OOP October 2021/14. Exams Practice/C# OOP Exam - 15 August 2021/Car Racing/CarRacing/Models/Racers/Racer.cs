using System;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;


namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private const int Driving_Experience_Min = 0;

        private const int Driving_Experience_Max = 100;

        private string username;

        private string racingBehavior;

        private int drivingExperience;

        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < Driving_Experience_Min || value > Driving_Experience_Max)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        public bool IsAvailable()
            => Car.FuelAvailable >= Car.FuelConsumptionPerRace;

        public virtual void Race() => Car.Drive();


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{GetType().Name}: {Username}")
                .AppendLine($"--Driving behavior: {RacingBehavior}")
                .AppendLine($"--Driving experience: {DrivingExperience}")
                .Append($"--Car: {Car}");

            return output.ToString();
        }
    }
}
