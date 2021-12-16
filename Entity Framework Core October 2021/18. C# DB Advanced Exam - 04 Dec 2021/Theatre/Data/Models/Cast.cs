namespace Theatre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Common;

    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Cast_FullName_Max_Lenght)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [MaxLength(EntityConstants.Cast_PhoneNumber_Max_Lenght)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }

    }
}
