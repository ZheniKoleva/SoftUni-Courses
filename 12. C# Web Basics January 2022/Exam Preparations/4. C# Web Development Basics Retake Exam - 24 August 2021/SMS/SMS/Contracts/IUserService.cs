using SMS.ViewModels;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool isRegistered, string error) Register(RegisterModel model);

        string Login(LoginModel model);

        string GetUsername(string userId);
    }
}
