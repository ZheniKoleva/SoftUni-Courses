using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;
        public CartsController(Request request, ICartService _cartService) 
            : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            IEnumerable<CartProductsListModel> products = cartService.AddToCart(productId, User.Id);

            var model = new
            {
                IsAuthenticated = true,
                Products = products
            };

            return View(model, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProducts(User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Details()
        {
            IEnumerable<CartProductsListModel> products = cartService.GetProducts(User.Id);

            var model = new
            {
                IsAuthenticated = true,
                Products = products
            };

            return View(model);
        }
    }
}
