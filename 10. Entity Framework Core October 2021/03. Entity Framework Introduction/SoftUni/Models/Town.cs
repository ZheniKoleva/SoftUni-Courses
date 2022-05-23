using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SoftUni.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("TownID")]
        public int TownId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Address.Town))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
