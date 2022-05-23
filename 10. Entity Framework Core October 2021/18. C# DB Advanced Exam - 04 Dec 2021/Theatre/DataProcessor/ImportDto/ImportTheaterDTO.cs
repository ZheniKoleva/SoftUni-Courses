namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportTheaterDTO
    {
        [Required]
        [MinLength(EntityConstants.Theatre_Name_Min_Lenght)]
        [MaxLength(EntityConstants.Theatre_Name_Max_Lenght)]
        public string Name { get; set; }

        [Required]
        [Range(EntityConstants.Theatre_NumberOfHalls_Min_Value, EntityConstants.Theatre_NumberOfHalls_Max_Value)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(EntityConstants.Theatre_Director_Min_Lenght)]
        [MaxLength(EntityConstants.Theatre_Director_Max_Lenght)]
        public string Director { get; set; }

        public IEnumerable<ImportTicketDTO> Tickets { get; set; }
    }

}
