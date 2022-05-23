using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();            
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]       
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedOn { get; set; }


        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public User Creator { get; set; }


        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object

