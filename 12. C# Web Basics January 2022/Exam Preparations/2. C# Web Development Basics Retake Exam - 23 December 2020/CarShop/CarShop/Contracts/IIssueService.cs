using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        CarIssuesModel GetCarIssues(string carId);

        bool AddIssue(IssueCreateModel model);

        void DeleteIssue(string issueId);

        void FixIssue(string issueId);
    }
}
