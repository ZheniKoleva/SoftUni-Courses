namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using Artillery.Common;

    public class Shell
    {
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        
        public double ShellWeight  { get; set; }

        [Required]
        [MaxLength(EntityConstants.Shell_Caliber_Max_Lenght)]
        public string Caliber  { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }

    }
}
