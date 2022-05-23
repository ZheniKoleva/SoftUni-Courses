using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        } 

        public void Register(RegisterModel model)
        {
            bool isUserExist = GetUserByUserName(model.UserName) != null;
           
            if (isUserExist)
            {
                throw new ArgumentException("User exists");
            }

            User user = new User
            {
                Username = model.UserName,
                Email = model.Email,
                Password = HashPassword(model.Password)
            };       

            repository.Add(user);
            repository.SaveChanges();
        }

        public (bool, IEnumerable<ErrorModel>) ValidateModel(RegisterModel model)
        {
            bool isValid  = true;
            List<ErrorModel> errors = new List<ErrorModel>();

            if (model.UserName == null || model.UserName.Length < 5 || model.UserName.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorModel("Username is required and should be between 5 and 20 symbols"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorModel("Email is required"));
            }

            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorModel("Passoword is required and should be between 6 and 20 symbols"));
            }

            if (model.ConfirmPassword == null || model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorModel("Passoword and ConfirmPasswords should match"));
            }


            return (isValid, errors);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginModel model)
        {
            bool isCorrect = false;
            string userId = string.Empty;

            User user = GetUserByUserName(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);                              
            }

            if (isCorrect)
            {   
                userId = user.Id;  
            }

            return (userId, isCorrect);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using( SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }       

        private User GetUserByUserName(string username)
        {
            return repository.All<User>()
                .FirstOrDefault(x => x.Username == username);
        }
    }
}
