using System.ComponentModel.DataAnnotations;

namespace BusStation.Contracts
{
    public interface IValidationService
    {
        IEnumerable<ValidationResult> IsValid (object model);
    }
}
