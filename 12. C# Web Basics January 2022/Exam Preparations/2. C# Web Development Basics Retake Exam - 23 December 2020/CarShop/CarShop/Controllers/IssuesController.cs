using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;

        private readonly IUserService userService;

        public IssuesController(Request request, IIssueService _issueService, IUserService _userService) 
            : base(request)
        {
            issueService = _issueService;
            userService = _userService;
        }

        [Authorize]
        public Response Add(string carId)
        {  
            return View(new { IsAuthenticated = true, CarId = carId });
        }

        [Authorize]
        [HttpPost]
        public Response Add(IssueCreateModel model)
        {
            bool isAdded = issueService.AddIssue(model);

            if (!isAdded)
            {
                return Redirect($"/Issues/Add?carId={model.CarId}");
            }

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            CarIssuesModel carData = issueService.GetCarIssues(carId);

            var model = new
            {
                IsAuthenticated = true,                
                carData.Model,
                carData.CarId,
                carData.Issues
            };

            return View(model);
        }


        [Authorize]
        public Response Delete(string issueId, string carId)
        {
            issueService.DeleteIssue(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public Response Fix(string issueId, string carId)
        {
            bool isUserMechanic = userService.IsUserMechanic(User.Id);

            if (isUserMechanic)
            {
                issueService.FixIssue(issueId);
            }
            

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
