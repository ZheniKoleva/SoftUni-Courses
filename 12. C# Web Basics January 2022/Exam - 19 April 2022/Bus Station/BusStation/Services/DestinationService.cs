using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Destinations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public DestinationService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public bool AddDestination(DestinationAddModel model)
        {
            bool isAdded = false;
            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (errors.Any())
            {
                return isAdded;
            }

            DateTime dateTime = DateTime.Parse(model.Date, CultureInfo.InvariantCulture, DateTimeStyles.None);

            if (dateTime < DateTime.UtcNow)
            {
                return isAdded;
            }

            string date = dateTime.ToString("d");
            string time = dateTime.ToString("t");

            Destination destination = new Destination()
            {
                DestinationName = model.DestinationName,
                Origin = model.Origin,
                Date = date,
                Time = time,
                ImageUrl = model.ImageUrl
            };

            
            repo.Add(destination);
            repo.SaveChanges();
            isAdded = true;

            return isAdded;            
        }


        public IEnumerable<DestinationsListModel> GetAllDestinations(string userId)
        {
            return repo.All<Destination>()
                .Include(x => x.Tickets)
                .Select(d => new DestinationsListModel()
                {
                    Id = d.Id,
                    DestinationName = d.DestinationName,
                    Origin = d.Origin,
                    ImageUrl = d.ImageUrl,
                    Date = d.Date,
                    Time = d.Time,
                    TicketsCount = d.Tickets
                        .Where(x => x.UserId != userId).Count()
                })
                .AsEnumerable();
        }
    }
}
