namespace CarShop.ViewModels
{
    public class CarsListModel
    {       
        public string Id { get; set; }
        
        public string Model { get; set; }       
        
        public string PictureUrl { get; set; }
       
        public string PlateNumber { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
