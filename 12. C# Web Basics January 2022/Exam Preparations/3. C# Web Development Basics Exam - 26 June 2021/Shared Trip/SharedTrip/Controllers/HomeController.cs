using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            var model = new
            {
                IsAuthenticated = User.IsAuthenticated
            };

            if (model.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View(model);
        }
    }
}