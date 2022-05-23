using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(Request request, ITicketService _ticketService) 
            : base(request)
        {
            ticketService = _ticketService;
        }

        [Authorize]
        public Response Create(int destinationId)
        {
            return View(new { IsAuthenticated = true,  destinationId} );
        }

        [Authorize]
        [HttpPost]
        public Response Create(int destinationId, TicketCreateModel model)
        {
            bool isAdded = ticketService.AddTicketToDestination(model, destinationId, User.Id);

            if (!isAdded)
            {
                return View(destinationId);
            }

            return Redirect("/Destinations/All");
        }

        [Authorize]        
        public Response Reserve(int destinationId)
        {
            bool isReserved = ticketService.ReserveTicket(destinationId, User.Id);

            if (!isReserved)
            {
                return Redirect("/Destinations/All");
            }

            return Redirect("/Destinations/All");
        }

        [Authorize]
        public Response MyTickets()
        {
            IEnumerable<MyTicketsListModel> tickets = ticketService.GetMyTickets(User.Id);
                        
            return View(new { IsAuthenticated = true, tickets });
        }

    }
}
