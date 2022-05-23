using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repository;

        public TripService(IRepository _repository)
        {
            repository = _repository;
        }


        public void AddTrip(TripInputModel model)
        {
            DateTime date = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None);

            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                DepartureTime = date
            };

            repository.Add(trip);
            repository.SaveChanges();
        }       

        public (bool isValid, IEnumerable<ErrorModel> errors) ValidateModel(TripInputModel model)
        {
            bool isValid = true;
            List<ErrorModel> errors = new List<ErrorModel>();           

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = false;
                errors.Add(new ErrorModel("Start point is required"));
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorModel("End point is required"));
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorModel("Description is required and should not be more than 80 symbols"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorModel("Seats should be between 2 and 6"));
            }

            if (!DateTime.TryParseExact(model.DepartureTime,"dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                isValid = false;
                errors.Add(new ErrorModel("Date is required"));
            }


            return (isValid, errors);
        }

        public IEnumerable<TripOutputModel> GetAll()
        {             
            return repository.All<Trip>()
                .Select(x => new TripOutputModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats
                });
        }

        public TripDetailsModel GetTripDetails(string tripId)
        {   
            return repository.All<Trip>()
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsModel()
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats
                })
                .FirstOrDefault();               
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            Trip trip = repository.All<Trip>()                
                .FirstOrDefault(x => x.Id == tripId);

            User user = repository.All<User>()
                .FirstOrDefault(x => x.Id == userId);

            bool isUserTripExist = repository.All<UserTrip>()
                .FirstOrDefault(x => x.UserId == userId && x.TripId == tripId) != null;

            if (isUserTripExist)
            {
                throw new ArgumentException("User has already added this trip");
            }

            if (user == null || trip == null)
            {
                throw new ArgumentException("Trip or user not found");
            }

            UserTrip userTrip = new UserTrip()
            {
                TripId = trip.Id,
                Trip = trip,
                UserId = userId,
                User = user
            };

            repository.Add(userTrip);
            repository.SaveChanges();
        }
    }
}
