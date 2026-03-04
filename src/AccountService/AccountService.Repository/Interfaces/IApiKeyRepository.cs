using AccountService.Domain;

namespace AccountService.Repository.Interfaces;

public interface IApiKeyRepository {
    Task<ApiKey?> GetByIdAsync(Guid id);
    Task<ApiKey?> GetByHashedKeyAsync(string hashedKey);
    Task<ApiKey?> GetByAccountIdAsync(Guid accountId);
    Task<ApiKey> CreateAsync(ApiKey apiKey);
    Task<ApiKey> UpdateAsync(ApiKey apiKey);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<ApiKey>> GetAllByAccountIdAsync(Guid accountId);
}

