using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public UserService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(x => x.Id == userId)?.Username;
        }

        public string Login(LoginModel model)
        {
            User user = repo.All<User>()
                .FirstOrDefault(x => x.Username == model.Username && x.Password == HashPassword(model.Password));

            return user?.Id;
        }

        public (bool isRegistered, string error) Register(RegisterModel model)
        {
            bool isRegistered = false;
            string errorString = string.Empty;

            var (isValid, error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            Cart cart = new Cart();
            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
                Cart = cart,
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistered = true;
            }
            catch (Exception e)
            {
                errorString = "Registration unsuccessfull";               
            }            

            return (isRegistered, errorString);
        }
        

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }       
    }
}
