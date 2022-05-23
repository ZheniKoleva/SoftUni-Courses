using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorModel> errors) ValidateModel(TripInputModel model);

        void AddTrip(TripInputModel model);

        IEnumerable<TripOutputModel> GetAll();

        TripDetailsModel GetTripDetails(string id);

        void AddUserToTrip(string tripId, string id);
    }
}
