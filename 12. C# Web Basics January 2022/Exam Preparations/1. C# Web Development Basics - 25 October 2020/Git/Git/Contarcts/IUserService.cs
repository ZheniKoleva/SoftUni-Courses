using Git.ViewModels;

namespace Git.Contarcts
{
    public interface IUserService
    {
        (bool isRegistered, string error) Register(RegisterModel model);

        string Login(LoginModel model);
    }
}
