namespace VaporStore.DataProcessor.Dto.Import
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportUserDTO
    {
        [Required]
        [MinLength(EntityConstants.User_Username_Min_Length)]
        [MaxLength(EntityConstants.User_Username_Max_Length)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(EntityConstants.User_FullName_Regex_Pattern)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(EntityConstants.User_Age_Min_Value, EntityConstants.User_Age_Max_Value)]
        public int Age { get; set; }

        [Required]
        [MinLength(EntityConstants.User_Cards_Min_Length)]
        public ImportCardDTO[] Cards { get; set; }

    }
}
