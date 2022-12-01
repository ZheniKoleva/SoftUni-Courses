using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TripAdministrations
{
    public class TripAdministrator : ITripAdministrator
    {
        private Dictionary<string, Company> companies = new Dictionary<string, Company>();
        private Dictionary<string, Trip> trips = new Dictionary<string, Trip>();
        private Dictionary<Company, HashSet<Trip>> companyTrips = new Dictionary<Company, HashSet<Trip>>();       

        public void AddCompany(Company c)
        {
            if (Exist(c))
            {
                throw new ArgumentException();
            }

            companies.Add(c.Name, c);
            companyTrips.Add(c, new HashSet<Trip>());
        }

        public void AddTrip(Company c, Trip t)
        {
            if (!Exist(c))
            {
                throw new ArgumentException();
            }

            var companyCurrentTrips = companyTrips[c].Count;

            if (companyCurrentTrips + 1 <= c.TripOrganizationLimit)
            {
                companyTrips[c].Add(t);
                trips.Add(t.Id, t);
            }
        }

        public bool Exist(Company c)
        {
            return companies.ContainsKey(c.Name);
        }

        public bool Exist(Trip t)
        {
            return trips.ContainsKey(t.Id);
        }

        public void RemoveCompany(Company c)
        {
            if (!Exist(c))
            {
                throw new ArgumentException();
            }

            var companyCurrTrips = companyTrips[c];
            companies.Remove(c.Name);
            companyTrips.Remove(c);

            foreach (var item in companyCurrTrips)
            {
                trips.Remove(item.Id);
            }
        }

        public IEnumerable<Company> GetCompanies()
        {
            return companies.Values;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return trips.Values;
        }

        public void ExecuteTrip(Company c, Trip t)
        {
            var company = Exist(c) ? companies[c.Name] : null;
            var trip = Exist(t) ? trips[t.Id] : null;            

            if (company == null || trip == null)
            {
                throw new ArgumentException();
            }

            var companyCurrTrips = companyTrips[company];

            if (!companyCurrTrips.Contains(trip))
            {
                throw new ArgumentException();
            }

            companyCurrTrips.Remove(trip);
            trips.Remove(trip.Id);
        }

        public IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n)
        {
            return companyTrips
                .Where(x => x.Value.Count > n)
                .Select(x => x.Key);
        }

        public IEnumerable<Trip> GetTripsWithTransportationType(Transportation t)
        {
            return trips.Values
                .Where(x => x.Transportation == t);
        }

        public IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi)
        {
            return trips.Values
                .Where(x => x.Price >= lo && x.Price <= hi);
        }
    }
}
