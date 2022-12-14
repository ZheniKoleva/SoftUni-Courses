using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public interface IAirlinesManager
    {
        void AddAirline(Airline airline);

        void AddFlight(Airline airline, Flight flight);

        bool Contains(Airline airline);

        bool Contains(Flight flight);

        void DeleteAirline(Airline airline);

        IEnumerable<Flight> GetAllFlights();

        Flight PerformFlight(Airline airline, Flight flight);

        IEnumerable<Flight> GetCompletedFlights();

        IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber();

        IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName();

        IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination);
    }
}
