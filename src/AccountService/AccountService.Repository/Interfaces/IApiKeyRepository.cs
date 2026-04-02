using AccountService.Domain;
using Shared.Repository;

namespace AccountService.Repository.Interfaces;

public interface IApiKeyRepository : IRepository<ApiKey>
{
    Task<ApiKey?> GetByHashedKeyAsync(string hashedKey);
    Task<ApiKey?> GetByAccountIdAsync(Guid accountId);
    Task<IEnumerable<ApiKey>> GetAllByAccountIdAsync(Guid accountId);
}

