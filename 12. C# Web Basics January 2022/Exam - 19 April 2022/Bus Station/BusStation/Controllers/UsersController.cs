using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Users;

namespace BusStation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;       

        public UsersController(Request request, IUserService _userService) 
            : base(request)
        {
            userService = _userService;            
        }

        public Response Login()
        {
            var model = new
            {
                IsAuthenticated = User.IsAuthenticated
            };

            return View(model);
        }

        [HttpPost]
        public Response Login(UserLoginModel model)
        {
            Request.Session.Clear();

            (string userId, bool isValid) = userService.IsLoginCorrect(model);

            if (!isValid)
            {
                return Redirect("/Users/Login");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);
            
            return Redirect("/Destinations/All");
        }

        public Response Register()
        {
            var model = new
            {
                IsAuthenticated = User.IsAuthenticated
            };

            return View(model);
        }

        [HttpPost]
        public Response Register(UserRegisterModel model)
        {
            bool isRegistered = userService.Register(model);

            if (!isRegistered)
            {
                return Redirect("/Users/Register");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
