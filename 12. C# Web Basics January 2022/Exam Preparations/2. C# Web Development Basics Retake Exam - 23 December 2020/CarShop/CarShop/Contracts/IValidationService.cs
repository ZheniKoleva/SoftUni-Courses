using System.ComponentModel.DataAnnotations;

namespace CarShop.Contracts
{
    public interface IValidationService
    {
        IEnumerable<ValidationResult> IsValid (object model);
    }
}
