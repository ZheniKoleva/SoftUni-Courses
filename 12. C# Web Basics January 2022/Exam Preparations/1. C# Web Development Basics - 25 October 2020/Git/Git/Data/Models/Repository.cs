using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            Id = Guid.NewGuid().ToString();            
            Commits = new HashSet<Commit>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type

