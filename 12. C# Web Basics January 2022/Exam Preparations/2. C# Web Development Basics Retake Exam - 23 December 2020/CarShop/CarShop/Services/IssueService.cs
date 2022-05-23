using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;        

        public IssueService(IRepository _repo, IValidationService _validationService)
        {
           repo = _repo;
           validationService = _validationService;          
        }

        public bool AddIssue(IssueCreateModel model)
        {
            bool isAdded = false;

            IEnumerable<ValidationResult> errors = validationService.IsValid(model);

            if (errors.Any())
            {
                return isAdded;
            }

            Issue issue = new Issue()
            {
                Description = model.Description,
                IsFixed = false,
                CarId = model.CarId,
            };

            try
            {
                repo.Add(issue);
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {
            }

            return isAdded;
        }


        public void DeleteIssue(string issueId)
        {
            Issue issueToDelete = repo.All<Issue>()
                .FirstOrDefault(x => x.Id == issueId);

            repo.Delete(issueToDelete);
            repo.SaveChanges();
        }


        public void FixIssue(string issueId)
        {
            Issue issueToFix = repo.All<Issue>()
                .FirstOrDefault(x => x.Id == issueId);

            issueToFix.IsFixed = true;

            repo.SaveChanges();
        }


        public CarIssuesModel GetCarIssues(string carId)
        {
            return repo.All<Car>()
                .Include(x => x.Issues)
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesModel()
                {
                    CarId = carId,
                    Model = $"{x.Year} {x.Model}",
                    Issues = x.Issues
                    .Select(x => new IssueModel()
                    {
                        Description = x.Description,
                        IsFixed = x.IsFixed ? "Yes" : "Not yet",
                        IssueId = x.Id
                    })
                    .ToList()
                })
                .FirstOrDefault();               
        }
    }
}
