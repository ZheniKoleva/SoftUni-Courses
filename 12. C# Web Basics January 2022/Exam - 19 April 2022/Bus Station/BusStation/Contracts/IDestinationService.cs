using BusStation.ViewModels.Destinations;

namespace BusStation.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<DestinationsListModel> GetAllDestinations(string userId);

        bool AddDestination(DestinationAddModel model);
    }
}
