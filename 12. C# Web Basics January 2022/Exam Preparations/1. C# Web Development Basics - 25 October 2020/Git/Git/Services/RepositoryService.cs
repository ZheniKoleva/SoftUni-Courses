using Git.Contarcts;
using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public RepositoryService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isCreated, string error) Create(RepositoryCreateModel model, string userId)
        {
            bool isCreated = false;
            string errorString = string.Empty;

            var (isValid, error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            Repository repository = new Repository()
            {
                Name = model.Name,
                OwnerId = userId,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == "Public"
            };

            try
            {
                repo.Add(repository);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                errorString = "Repository was not created";
            }


            return (isCreated, errorString);
        }

        public IEnumerable<RepositoryListModel> GetAllRepositories()
        {
            return repo.All<Repository>()
                .Include(x => x.Owner)
                .Where(x => x.IsPublic == true)
                .Select(x => new RepositoryListModel()
                {
                   Id = x.Id,
                   Name = x.Name,
                   Owner = x.Owner.Username,
                   CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                   CommitsCount = x.Commits.Count
                })
                .AsEnumerable();
        }

        public string GetRepositoryName(string repoId)
        {
            return repo.All<Repository>()
                .FirstOrDefault(x => x.Id == repoId)?.Name;
        }
    }
}
