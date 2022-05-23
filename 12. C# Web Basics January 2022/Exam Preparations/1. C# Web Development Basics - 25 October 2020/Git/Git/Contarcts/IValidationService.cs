namespace Git.Contarcts
{
    public interface IValidationService
    {
        (bool isValid, string error) ValidateModel(object model);
    }
}
