using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        bool AddPlayer(PlayerCreateModel model, string userId);

        IEnumerable<PlayersListModel> GetAllPlayers();

        IEnumerable<PlayersListModel> GetPlayersByUserId(string userId);

        void AddPlayerToCollection(int playerId, string userId);

        void RemovePlayerFromCollection(int playerId, string userId);
    }
}
