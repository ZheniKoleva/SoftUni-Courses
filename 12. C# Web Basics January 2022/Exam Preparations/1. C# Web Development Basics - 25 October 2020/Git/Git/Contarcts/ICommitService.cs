using Git.ViewModels;

namespace Git.Contarcts
{
    public interface ICommitService
    {
        (bool isCreated, string error) Create(CommitCreateModel model, string userId);

        IEnumerable<CommitListModel> GetAllCommits(string userId);
    }
}
