using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels
{
    public class RepositoryCreateModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Name { get; set; }        

        [Required]
        public string RepositoryType { get; set; }        
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type

