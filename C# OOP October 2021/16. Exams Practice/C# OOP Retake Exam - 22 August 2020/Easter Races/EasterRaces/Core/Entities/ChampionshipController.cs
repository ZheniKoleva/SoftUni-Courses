using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int Participants_Count_Min = 3;

        private readonly IRepository<ICar> carRepo;

        private readonly IRepository<IDriver> driverRepo;

        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            carRepo = new CarRepository();
            driverRepo = new DriverRepository();                
            raceRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepo.GetByName(driverName);
            ICar car = carRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepo.GetByName(raceName);
            IDriver driver = driverRepo.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = carRepo.GetByName(model);

            if ( car != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }           

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            { 
                car = new SportsCar(model, horsePower);
            }

            carRepo.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {       
            IDriver driver = driverRepo.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            driverRepo.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepo.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);

            raceRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }           

            if (driverRepo.GetAll().Count() < Participants_Count_Min)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceInvalid, raceName, Participants_Count_Min));
            }

            List<IDriver> participants = driverRepo.GetAll()
               .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
               .Take(3)
               .ToList();            

            participants.First().WinRace();

            raceRepo.Remove(race);

            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format(OutputMessages.DriverFirstPosition, participants[0].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, participants[1].Name, raceName))
                .Append(string.Format(OutputMessages.DriverThirdPosition, participants[2].Name, raceName));

            return output.ToString();
        }
    }
}
