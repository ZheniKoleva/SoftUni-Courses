using System.ComponentModel.DataAnnotations;

namespace FootballManager.Contracts
{
    public interface IValidationService
    {
        IEnumerable<ValidationResult> IsValid (object model);
    }
}
