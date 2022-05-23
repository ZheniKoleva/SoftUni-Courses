using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public PlayerService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public bool AddPlayer(PlayerCreateModel model, string userId)
        {
            bool isValid = false;
            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (errors.Any())
            {
                return isValid;
            }

            User user = GetUserById(userId);

            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            UserPlayers userPlayer = new UserPlayers()
            {
                User = user,
                Player = player,
            };

            try
            {
                repo.Add(userPlayer);                
                repo.SaveChanges();
                isValid = true;
            }
            catch (Exception)
            {
            }
            
            return isValid;
        }

        public void AddPlayerToCollection(int playerId, string userId)
        {
            User user = GetUserById(userId);
            Player player = GetPlayerById(playerId);

            bool isPlayerInCollection = user.UserPlayers
                .Any(x => x.PlayerId == playerId && x.UserId == userId);

            if (!isPlayerInCollection)
            {
                UserPlayers userPlayer = new UserPlayers()
                {
                    User = user,
                    Player = player,
                };

                repo.Add(userPlayer);
                repo.SaveChanges();
            }

        }

        public IEnumerable<PlayersListModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayersListModel()
                {
                    Id = p.Id,  
                    FullName = p.FullName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Endurance = p.Endurance,
                    Speed = p.Speed,
                    Position = p.Position,
                })
                .AsEnumerable();
        }

        public IEnumerable<PlayersListModel> GetPlayersByUserId(string userId)
        {
            return repo.All<UserPlayers>()
                .Where(x => x.UserId == userId)
                .Select(p => p.Player)                
                .Select(p => new PlayersListModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Endurance = p.Endurance,
                    Speed = p.Speed,
                    Position = p.Position,
                })
                .AsEnumerable();
        }

        private User GetUserById(string userId)
        {
            return repo.All<User>()
                .Include(x => x.UserPlayers)
                .FirstOrDefault(x => x.Id == userId);
        }

        private Player GetPlayerById(int playerId)
        {
            return repo.All<Player>()
                .FirstOrDefault(x => x.Id == playerId);
        }

        public void RemovePlayerFromCollection(int playerId, string userId)
        {
            UserPlayers playerToRemove = repo.All<UserPlayers>()
                .FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            if (playerToRemove != null)
            {
                repo.Delete(playerToRemove);
                repo.SaveChanges();
            }
        }
    }
}
