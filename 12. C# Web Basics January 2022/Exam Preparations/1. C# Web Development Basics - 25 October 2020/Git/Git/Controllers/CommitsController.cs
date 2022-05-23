using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contarcts;
using Git.ViewModels;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        private readonly IRepositoryService repositoryService;


        public CommitsController(Request request, ICommitService _commitService, IRepositoryService _repositoryService) 
            : base(request)
        {
            commitService = _commitService;
            repositoryService = _repositoryService;
        }

        [Authorize]
        public Response Create(string repoId)
        {
            string repoName = repositoryService.GetRepositoryName(repoId);

            var model = new
            {
                IsAuthorised = true,
                RepositoryName = repoName
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public Response Create(CommitCreateModel model)
        {
            var (isCreated, error) = commitService.Create(model, User.Id);

            if (!isCreated)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Commits/All");           
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<CommitListModel> commits = commitService.GetAllCommits(User.Id);

            var model = new
            {
                IsAuthenticated = User.IsAuthenticated,
                Commits = commits
            };

            return View(model);
        }
    }
}
