using CarShop.Contracts;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Services
{
    public class ValidationService : IValidationService
    {
        public IEnumerable<ValidationResult> IsValid (object model)
        {
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> errorResult = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, errorResult, true);

            return errorResult;
        }
    }
}
