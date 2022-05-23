using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request, IPlayerService _playerService) 
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(PlayerCreateModel model)
        {
            bool isCreated = playerService.AddPlayer(model, User.Id);

            if (!isCreated)
            {
                return View();
            }

            return Redirect("/Players/All");
        }


        [Authorize]
        public Response All()
        {
            IEnumerable<PlayersListModel> players = playerService.GetAllPlayers();

            return View(new { IsAuthenticated = true, players });
        }

        [Authorize]
        public Response Collection()
        {
            IEnumerable<PlayersListModel> players = playerService.GetPlayersByUserId(User.Id);

            return View(new { IsAuthenticated = true, players });
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            playerService.AddPlayerToCollection(playerId, User.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            playerService.RemovePlayerFromCollection(playerId, User.Id);

            return Redirect("/Players/Collection");
        }

    }
}
