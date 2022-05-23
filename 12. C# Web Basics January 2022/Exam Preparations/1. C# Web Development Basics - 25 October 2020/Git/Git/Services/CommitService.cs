using Git.Contarcts;
using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public CommitService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isCreated, string error) Create(CommitCreateModel model, string userId)
        {
            bool isCreated = false;
            string errorString = string.Empty;

            var (isValid, error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            Commit commit = new Commit()
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = model.Id                
            };

            try
            {
                repo.Add(commit);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                errorString = "Commit was not created";
            }


            return (isCreated, errorString);
        }
       
        public IEnumerable<CommitListModel> GetAllCommits(string userId)
        {
            return repo.All<Commit>()
                .Where(x => x.CreatorId == userId)
                .Include(x => x.Repository)                
                .Select(x => new CommitListModel()
                {
                    Id = x.Id,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                })
                .ToList();
        }
    }
}
