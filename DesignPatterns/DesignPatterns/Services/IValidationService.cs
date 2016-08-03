namespace DesignPatterns.Services
{
    public interface IValidationService
    {
        bool IsArgumentValid(string[] args);
    }
}