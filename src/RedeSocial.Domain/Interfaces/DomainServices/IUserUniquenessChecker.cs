namespace RedeSocial.Domain.Interfaces.DomainServices
{
    public interface IUserUniquenessChecker
    {
        Task<bool> IsUniqueAsync(string username);
    }
}
