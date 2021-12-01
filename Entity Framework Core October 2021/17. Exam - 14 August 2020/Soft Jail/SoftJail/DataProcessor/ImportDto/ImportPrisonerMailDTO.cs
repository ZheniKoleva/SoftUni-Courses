namespace SoftJail.DataProcessor.ImportDto
{
    using System;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportPrisonerMailDTO
    {
        [JsonProperty(nameof(FullName))]
        [Required]
        [MinLength(EntityConstants.Prisoner_FullName_Min_Length)]
        [MaxLength(EntityConstants.Prisoner_FullName_Max_Length)]
        public string FullName { get; set; }

        [JsonProperty(nameof(Nickname))]
        [Required]
        [RegularExpression(EntityConstants.Prisoner_Nickname_Regex_Pattern)]
        public string Nickname { get; set; }

        [JsonProperty(nameof(Age))]
        [Range(EntityConstants.Prisoner_Age_Min, EntityConstants.Prisoner_Age_Max)]
        public int Age { get; set; }

        [JsonProperty(nameof(IncarcerationDate))]
        [Required]
        public string IncarcerationDate { get; set; }

        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; }

        [JsonProperty(nameof(Bail))]
        [Range(typeof(decimal), EntityConstants.Prisoner_Bail_Min, EntityConstants.Prisoner_Bail_Max)]
        public decimal? Bail { get; set; }

        [JsonProperty(nameof(CellId))]
        public int? CellId { get; set; }

        [JsonProperty(nameof(Mails))]
        public  ImportMailDTO[] Mails { get; set; }

    }
}
