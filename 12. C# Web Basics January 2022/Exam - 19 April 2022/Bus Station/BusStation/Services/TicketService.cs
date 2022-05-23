using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Tickets;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public TicketService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public bool AddTicketToDestination(TicketCreateModel model, int destinationId, string userId)
        {          
            bool isAdded = false;
            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (errors.Any())
            {
                return isAdded;
            }           

            HashSet<Ticket> tickets = new HashSet<Ticket>();

            for (int i = 0; i < model.TicketsCount; i++)
            {
                Ticket ticket = new Ticket()
                {
                    Price = model.Price,
                    DestinationId = destinationId,
                    UserId = userId
                };

                repo.Add(ticket);
            };
           
            repo.SaveChanges();
            isAdded = true;

            return isAdded;
        }

        public IEnumerable<MyTicketsListModel> GetMyTickets(string userId)
        {
            var myTickets = repo.All<User>()
                .Where(x => x.Id == userId);

            return null;
            //return myTickets
            //    .Select(x => new MyTicketsListModel()
            //    {
            //         DestinationImage = x.Destination.ImageUrl,
            //         Destination = x.Destination.Origin,
            //         SingleTicket = x.Price.ToString("F2"),
            //         DateAndTime = $"Date: {x.Destination.Date}, Hour: {x.Destination.Time}"
            //    })
            //    .AsEnumerable();
        }

        public bool ReserveTicket(int destinationId, string userId)
        {
            bool isReserved = false;

            Ticket ticketAvailable = repo.All<Ticket>()
                .FirstOrDefault(x => x.DestinationId == destinationId && x.UserId != userId);

            if (ticketAvailable == null)
            {
                return isReserved;
            }

            User user = repo.All<User>()
                .FirstOrDefault(x => x.Id == userId);

            user.Tickets.Add(ticketAvailable);

            repo.SaveChanges();
            isReserved = true;

            return isReserved;
        }
    }
}
