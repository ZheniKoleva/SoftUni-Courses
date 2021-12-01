namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SoftJail.Common;

    public class Prisoner
    {
        public Prisoner()
        {
            Mails = new HashSet<Mail>();
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Prisoner_FullName_Max_Length)]
        public string FullName { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Range(EntityConstants.Prisoner_Age_Min, EntityConstants.Prisoner_Age_Max)]
        public int Age { get; set; }

        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }
        
        [Range(typeof(decimal), EntityConstants.Prisoner_Bail_Min, EntityConstants.Prisoner_Bail_Max)]
        public decimal? Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int? CellId { get; set; }
        public virtual Cell Cell { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }

        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }


}