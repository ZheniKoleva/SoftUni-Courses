using BusStation.ViewModels.Tickets;

namespace BusStation.Contracts
{
    public interface ITicketService
    {
        bool AddTicketToDestination(TicketCreateModel model, int destinationId, string userId);

        bool ReserveTicket(int destinationId, string userId);

        IEnumerable<MyTicketsListModel> GetMyTickets(string userId);
    }
}
