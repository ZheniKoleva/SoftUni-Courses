﻿using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
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

        public (string userId, bool isValid) IsLoginCorrect(UserLoginModel model)
        {
            bool isValid = false;
            string userId = string.Empty;

            IEnumerable<ValidationResult> errors = validationService.IsValid(model);            

            if (errors.Any() )
            {                
                return (userId, isValid);
            }

            User user = repo.All<User>().FirstOrDefault(x => x.Username == model.Username);                                              
         
            if(user != null)
            {
                userId = user.Id;
                isValid = user.Password == HashPassword(model.Password);
            }           

            return (userId, isValid);
        }

        public bool Register(UserRegisterModel model)
        {
            bool isRegistered = false;

            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (!errors.Any())
            {
                User user = new User()
                {
                    Username = model.Username,
                    Password = HashPassword(model.Password),
                    Email = model.Email,
                    IsMechanic = model.UserType == "Mechanic"
                };

                try
                {
                    repo.Add(user);
                    repo.SaveChanges();
                    isRegistered = true;
                }
                catch (Exception)
                {
                }
            }

            return isRegistered;
        }

        public bool IsUserMechanic(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(x => x.Id == userId).IsMechanic;
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
