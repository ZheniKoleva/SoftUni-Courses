using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            bool isRaceOneAvailable = racerOne.IsAvailable();
            bool isRaceTwoAvailable = racerTwo.IsAvailable();

            if (!isRaceOneAvailable && !isRaceTwoAvailable)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (isRaceOneAvailable && !isRaceTwoAvailable)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (!isRaceOneAvailable && isRaceTwoAvailable)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double winningChanceOne = CalculateWinnigChance(racerOne);
            double winningChanceTwo = CalculateWinnigChance(racerTwo);

            IRacer winner = winningChanceOne > winningChanceTwo ? racerOne : racerTwo;            
              
            return string.Format(OutputMessages.RacerWinsRace,
                racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double CalculateWinnigChance(IRacer racer)
        {
            double multiplier = 0;

            if (racer.RacingBehavior == "strict")
            {
                multiplier = 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                multiplier = 1.1;
            }

            return racer.Car.HorsePower * racer.DrivingExperience * multiplier;

        }
       
    }
}
