using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;

        private RacerRepository racers;

        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = CreateCar(type, make, model, VIN, horsePower);

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
        }
               

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = CreateRacer(type, username, car);

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

       

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = racers.FindBy(racerOneUsername);
            IRacer secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (secondRacer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            IEnumerable<IRacer> ordered = racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username);

            StringBuilder report = new StringBuilder();

            foreach (var racer in ordered)
            {
                report.AppendLine(racer.ToString());
            }

            return report.ToString().TrimEnd();
        }

        private ICar CreateCar(string type, string make, string model, string vIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, vIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, vIN, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType),
            };

            return car;
        }


        private IRacer CreateRacer(string type, string username, ICar car)
        {
            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),
                nameof(StreetRacer) => new StreetRacer(username, car),
                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType),
            };

            return racer;
        }
    }
}
