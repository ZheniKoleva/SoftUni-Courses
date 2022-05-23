using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contarcts;
using Git.ViewModels;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(Request request, IRepositoryService _repositoryService) 
            : base(request)
        {
            repositoryService = _repositoryService;
        }
        
        public Response All()
        {
            IEnumerable<RepositoryListModel> repositories = repositoryService.GetAllRepositories();

            var model = new
            {
                IsAuthenticated = User.IsAuthenticated,
                repositories
            };

            return View(repositories);
        }

        [Authorize]
        public Response Create()
        {
            return View(new { IsAuthenticated = true });
        }        

        [Authorize]
        [HttpPost]
        public Response Create(RepositoryCreateModel model)
        {
            var (isCreated, error) = repositoryService.Create(model, User.Id);

            if (!isCreated)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Repositories/All");
        }
    }
}
