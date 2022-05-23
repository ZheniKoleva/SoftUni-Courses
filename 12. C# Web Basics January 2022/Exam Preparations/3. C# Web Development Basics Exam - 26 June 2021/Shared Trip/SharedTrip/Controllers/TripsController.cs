using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(Request request, ITripService _tripService) 
            : base(request)
        {
            tripService = _tripService;
        }


        [Authorize]
        public Response Add()
        {
            var model = new
            {
                IsAuthenticated = User.IsAuthenticated
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public Response Add(TripInputModel model)
        {
            var (isValid, errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }            
            catch (Exception)
            {
                //return View(new List<ErrorModel>() { new ErrorModel("Unexpected error") }, "/Error");
                return Redirect("/Trips/Add");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]       
        public Response All()
        {
            IEnumerable<TripOutputModel> trips = tripService.GetAll();

            var model = new
            {
                IsAuthenticated = User.IsAuthenticated,
                trips
            };

            return View(model);
        }

        [Authorize]
        public Response Details(string tripId)
        {
            TripDetailsModel details = tripService.GetTripDetails(tripId);

            var model = new
            {
                IsAuthenticated = User.IsAuthenticated,
                StartPoint = details.StartPoint,
                ImagePath = details.ImagePath,
                EndPoint = details.EndPoint,
                DepartureTime = details.DepartureTime,
                Seats = details.Seats,
                Description = details.Description,
                Id = details.Id,
            };

            return View(model);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {            
            try
            {
                tripService.AddUserToTrip(tripId, User.Id);
            }
            catch (ArgumentException)
            {
                //return View(new List<ErrorModel>() { new ErrorModel(ae.Message) }, "/Error");
                return Redirect($"/Trips/Details?tripId={tripId}");
            }
            catch (Exception)
            {
                //return View(new List<ErrorModel>() { new ErrorModel("Unexpected Error") }, "/Error");
                return Redirect($"/Trips/Deails?tripId={tripId}");
            }

            return Redirect("/Trips/All");
        }
    }
}
