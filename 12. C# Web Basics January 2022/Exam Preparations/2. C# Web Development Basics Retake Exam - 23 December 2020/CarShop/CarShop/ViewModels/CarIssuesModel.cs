namespace CarShop.ViewModels
{
    public class CarIssuesModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public IEnumerable<IssueModel> Issues { get; set; }
       
    }
}
