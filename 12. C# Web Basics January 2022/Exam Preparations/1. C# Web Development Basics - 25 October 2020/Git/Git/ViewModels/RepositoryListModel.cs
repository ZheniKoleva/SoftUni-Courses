namespace Git.ViewModels
{
    public class RepositoryListModel
    {       
        public string Id { get; set; }
               
        public string Name { get; set; }
               
        public string CreatedOn { get; set; }            
        
        public string Owner { get; set; }

        public int CommitsCount { get; set; }
    }
}
