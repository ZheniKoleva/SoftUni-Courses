using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private readonly Dictionary<string, Airline> airlines;
        private readonly Dictionary<string, Flight> flights;

        public AirlinesManager()
        {
            airlines = new Dictionary<string, Airline>();
            flights = new Dictionary<string, Flight>();
        }

        public void AddAirline(Airline airline)
        {
            if (!Contains(airline))
            {
                airlines.Add(airline.Id, airline);
            }
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline))
            {
                throw new ArgumentException();
            }

            airline.flights.Add(flight);           
            flights.Add(flight.Id, flight);
        }

        public bool Contains(Airline airline)
        {
            return airlines.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flights.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            if (!Contains(airline))
            {
                throw new ArgumentException();
            }

            var flightsToDelete = airline.flights;
            airlines.Remove(airline.Id);

            foreach (var flight in flightsToDelete)
            {
                flights.Remove(flight.Id);
            }
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return airlines.Values
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.flights.Count)
                .ThenBy(x => x.Name);
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            Predicate<Flight> doesMatchTheCondition = (f) =>
                    f.Origin == origin && f.Destination == destination && f.IsCompleted == false;

            return airlines.Values
                .Where(x => x.flights.Any(f => doesMatchTheCondition(f)));
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return flights.Values
                .Where(x => x.IsCompleted == true);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return flights.Values
                .OrderBy(x => x.IsCompleted)
                .ThenBy(x => x.Number);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline) || !Contains(flight) || !airline.flights.Contains(flight))
            {
                throw new ArgumentException();
            }

            var flightToReturn = flights[flight.Id];
            flightToReturn.IsCompleted = true;

            return flightToReturn;
        }
    }
}
