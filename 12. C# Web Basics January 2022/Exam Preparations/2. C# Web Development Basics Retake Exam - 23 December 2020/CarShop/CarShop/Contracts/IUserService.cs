using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        (string userId, bool isValid) IsLoginCorrect(UserLoginModel model);

        bool Register(UserRegisterModel model);

        bool IsUserMechanic(string userId);
    }
}
