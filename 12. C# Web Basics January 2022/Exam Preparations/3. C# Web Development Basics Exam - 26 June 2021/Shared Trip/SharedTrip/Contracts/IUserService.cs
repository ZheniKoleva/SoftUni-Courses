using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {   
        public void Register(RegisterModel model);

        (bool, IEnumerable<ErrorModel>) ValidateModel(RegisterModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginModel model);
    }
}
