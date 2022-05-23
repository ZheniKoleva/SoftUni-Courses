using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public CarService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public bool AddCar(CarCreateModel model, string userId)
        {
            bool isCreated = false;

            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (errors.Any())
            {
                return isCreated;
            }

            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.ImageUrl,
                PlateNumber = model.PlateNumber,
                OwnerId = userId
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
            }

            return isCreated;
        }

        public IEnumerable<CarsListModel> GetAll(string userId, bool isUserMechanic)
        {   
            IEnumerable<Car> allCars = repo.All<Car>()
                .Include(x => x.Issues)
                .AsEnumerable();

            allCars = isUserMechanic
                ? allCars.Where(x => x.Issues.Any(i => i.IsFixed == false))
                : allCars.Where(x => x.OwnerId == userId);

            return allCars
                .Select(x => new CarsListModel()
                {
                    Id = x.Id,
                    PlateNumber = x.PlateNumber,
                    PictureUrl = x.PictureUrl,
                    Model = $"{x.Year} {x.Model}",
                    FixedIssues = x.Issues.Count(x => x.IsFixed == true),
                    RemainingIssues = x.Issues.Count(x => x.IsFixed == false)
                })
                .ToList();
        }

        
    }
}
