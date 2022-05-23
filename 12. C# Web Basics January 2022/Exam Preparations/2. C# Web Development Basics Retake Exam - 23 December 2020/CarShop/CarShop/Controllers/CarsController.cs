using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        private readonly IUserService userService;

        public CarsController(Request request, ICarService _carService, IUserService _userService) 
            : base(request)
        {
            carService = _carService;
            userService = _userService;
        }

        [Authorize]
        public Response All()
        {
            bool isUserMechanic = userService.IsUserMechanic(User.Id);

            IEnumerable<CarsListModel> cars = carService.GetAll(User.Id, isUserMechanic);

            var model = new
            {
                IsAuthenticated = true,
                cars
            };

            return View(model);
        }

        [Authorize]
        public Response Add()
        {
            bool isUserMechanic = userService.IsUserMechanic(User.Id);

            if (isUserMechanic)
            {
                return Redirect("/Cars/All");
            }

            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(CarCreateModel model)
        {
            bool isCreated = carService.AddCar(model, User.Id);

            if (!isCreated)
            {
                return View(new { IsAuthenticated = true });
            }


            return Redirect("/Cars/All");
        }
    }
}
