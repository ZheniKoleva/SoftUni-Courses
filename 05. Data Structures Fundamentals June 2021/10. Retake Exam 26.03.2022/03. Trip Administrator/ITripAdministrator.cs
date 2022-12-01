using System;
using System.Collections.Generic;

namespace TripAdministrations
{
    public interface ITripAdministrator
    {
        void AddCompany(Company c);

        void AddTrip(Company c, Trip t);

        bool Exist(Company c);

        bool Exist(Trip t);

        void RemoveCompany(Company c);

        IEnumerable<Company> GetCompanies();

        IEnumerable<Trip> GetTrips();

        void ExecuteTrip(Company c, Trip t);

        IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n);

        IEnumerable<Trip> GetTripsWithTransportationType(Transportation t);

        IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi);
    }
}
