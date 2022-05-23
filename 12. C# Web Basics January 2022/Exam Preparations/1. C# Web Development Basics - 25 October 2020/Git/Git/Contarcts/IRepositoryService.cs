using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contarcts
{
    public interface IRepositoryService
    {
        IEnumerable<RepositoryListModel> GetAllRepositories();

        (bool isCreated, string error) Create(RepositoryCreateModel model, string userId);
        string GetRepositoryName(string repoId);
    }
}
