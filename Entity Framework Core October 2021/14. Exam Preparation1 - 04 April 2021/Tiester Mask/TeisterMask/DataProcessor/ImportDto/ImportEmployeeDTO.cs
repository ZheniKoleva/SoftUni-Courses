using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDTO
    {
        [JsonProperty("Username")]
        [Required]
        [MaxLength(EntityConstants.EMPLOYEE_USERNAME_MAX_LENGTH)]
        [MinLength(EntityConstants.EMPLOYEE_USERNAME_MIN_LENGTH)]
        [RegularExpression(EntityConstants.EMPLOYEE_USERNAME_REGEX)]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [JsonProperty("Phone")]
        [Required]
        [RegularExpression(EntityConstants.EMPLOYEE_PHONE_REGEX)]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public ICollection<int> TasksId { get; set; }
    }
}
