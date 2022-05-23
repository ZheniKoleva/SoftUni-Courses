using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Repositories = new HashSet<Repository>();
            Commits = new HashSet<Commit>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; }

        public ICollection<Commit> Commits { get; set; }

    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has Repositories collection – a Repository type
//•	Has Commits collection – a Commit type

