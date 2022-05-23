using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.ViewModels;
using System;

namespace SharedTrip.Controllers
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

            if (model.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View(model);
        }

        public Response Register()
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


        [HttpPost]
        public Response Register(RegisterModel model)
        {
            var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.Register(model);
            }
            catch (ArgumentException ex)
            {
                //return View(new List<ErrorModel>() { new ErrorModel(ex.Message) }, "/Error");
                return Redirect("/Users/Register");
            }
            catch (Exception)
            {
                //return View(new List<ErrorModel>() { new ErrorModel("Unexpected error") }, "/Error" );
                return Redirect("/Users/Register");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginModel model)
        {
            Request.Session.Clear();

            (string userId, bool isCorrect) = userService.IsLoginCorrect(model);

            if(isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/Trips/All");
            }

            //return View(new List<ErrorModel>() { new ErrorModel("Incorect login details") }, "/Error");
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
