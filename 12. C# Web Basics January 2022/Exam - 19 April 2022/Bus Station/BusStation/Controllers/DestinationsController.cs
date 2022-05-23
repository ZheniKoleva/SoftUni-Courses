using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Destinations;

namespace BusStation.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(Request request, IDestinationService _destinationService)
            : base(request)
        {
            destinationService = _destinationService;
        }


        [Authorize]
        public Response All()
        {
            IEnumerable<DestinationsListModel> destinations = destinationService.GetAllDestinations(User.Id);

            return View(new { IsAuthenticated = true, destinations });            
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(DestinationAddModel model)
        {
            bool isAdded = destinationService.AddDestination(model);

            if (!isAdded)
            {
                return View();
            }

            return Redirect("/Destinations/All");
        }
    }
}
