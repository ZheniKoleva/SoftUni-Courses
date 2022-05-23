using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contarcts;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
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

        public Response Register()
        {
            var model = new
            {
                IsAuthenticated = User.IsAuthenticated
            };
            
            return View(model);
        }

        [HttpPost]
        public Response Register(RegisterModel model)
        {
            var (isRegistered, error) = userService.Register(model);

            if (!isRegistered)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginModel model)
        {
            Request.Session.Clear();

            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { ErrorMessage = "Invalid credentials" }, "/Error");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
