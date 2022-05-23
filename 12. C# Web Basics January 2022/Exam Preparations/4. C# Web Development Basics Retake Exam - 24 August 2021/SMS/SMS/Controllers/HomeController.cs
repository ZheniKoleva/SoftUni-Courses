using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        private readonly IProductService productService;

        public HomeController(Request request, IUserService _userService, IProductService _productService)
            : base(request)
        {
            userService = _userService;
            productService = _productService;
        } 

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string userName = userService.GetUsername(User.Id);

                IEnumerable<ProductsListModel> products = productService.GetProducts();

                var model = new
                {
                    IsAuthenticated = true,
                    Username = userName,
                    Products = products
                };

                return View(model, "Home/IndexLoggedIn");

            } 

            return View(new { IsAuthenticated = false });
        }
    }
}