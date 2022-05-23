using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels
{
    public class CommitCreateModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "{0} should be with more than {1} symbols")]
        public string Description { get; set; }

        [Required]
        public string Id { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object
