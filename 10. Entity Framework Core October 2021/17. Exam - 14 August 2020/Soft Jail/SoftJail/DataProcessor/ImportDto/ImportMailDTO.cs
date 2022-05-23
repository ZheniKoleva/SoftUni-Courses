namespace SoftJail.DataProcessor.ImportDto
{  
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    using SoftJail.Common;

    public class ImportMailDTO
    {
        [JsonProperty(nameof(Description))]
        [Required]
        public string Description { get; set; }

        [JsonProperty(nameof(Sender))]
        [Required]
        public string Sender { get; set; }

        [JsonProperty(nameof(Address))]
        [Required]
        [RegularExpression(EntityConstants.Mail_Address_Regex_Pattern)]
        public string Address { get; set; }

    }
}
