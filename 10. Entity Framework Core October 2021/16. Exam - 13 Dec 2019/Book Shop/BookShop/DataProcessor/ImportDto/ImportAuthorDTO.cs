namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportAuthorDTO
    {
        [JsonProperty(nameof(FirstName))]
        [Required]
        [MaxLength(EntityConstant.Author_FirstName_Max_Length)]
        [MinLength(EntityConstant.Author_FirstName_Min_Length)]
        public string FirstName { get; set; }

        [JsonProperty(nameof(LastName))]
        [Required]
        [MaxLength(EntityConstant.Author_LastName_Max_Length)]
        [MinLength(EntityConstant.Author_LastName_Min_Length)]
        public string LastName { get; set; }

        [JsonProperty(nameof(Phone))]
        [Required]
        [StringLength(EntityConstant.Author_Phone_Length)]
        [RegularExpression(EntityConstant.Author_Phone_RegexPattern)]
        public string Phone { get; set; }

        [JsonProperty(nameof(Email))]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty(nameof(Books))]
        [Required]
        [MinLength(EntityConstant.Author_BooksCollection_Min_Length)]
        public ImportBookId[] Books { get; set; }

    }
}
