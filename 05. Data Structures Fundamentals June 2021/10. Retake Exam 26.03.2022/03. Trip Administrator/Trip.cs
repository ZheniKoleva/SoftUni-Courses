using System;
namespace TripAdministrations
{
    public class Trip
    {
        public Trip(string id, int peopleLimit, Transportation transportation, int price)
        {
            this.Id = id;
            this.PeopleLimit = peopleLimit;
            this.Transportation = transportation;
            this.Price = price;
        }

        public string Id { get; set; }

        public int PeopleLimit { get; set; }

        public Transportation Transportation { get; set; }

        public int Price { get; set; }
    }
}
