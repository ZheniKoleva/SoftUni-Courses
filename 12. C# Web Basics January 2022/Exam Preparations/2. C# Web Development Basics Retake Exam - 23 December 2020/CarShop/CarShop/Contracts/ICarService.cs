using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarsListModel> GetAll(string userId, bool isUserMechanic);

        bool AddCar(CarCreateModel model, string userId);
    }
}
