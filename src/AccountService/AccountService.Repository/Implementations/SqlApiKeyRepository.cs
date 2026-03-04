using AccountService.Domain;
using AccountService.Infrastructure;
using AccountService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository.Implementations;

public class SqlApiKeyRepository(AccountDbContext dbContext)
    : BaseRepository<ApiKey, AccountService.Infrastructure.Models.ApiKey>(dbContext), IApiKeyRepository
{
    protected override DbSet<AccountService.Infrastructure.Models.ApiKey> GetDbSet() {
        return DbContext.ApiKeys;
    }

    protected override ApiKey MapToDomain(AccountService.Infrastructure.Models.ApiKey infraApiKey) {
        return new ApiKey {
            Id = infraApiKey.Id,
            AccountId = infraApiKey.AccountId,
            HashedKey = infraApiKey.HashedKey,
            CreatedAt = infraApiKey.CreatedAt,
            IsActive = infraApiKey.IsActive
        };
    }

    protected override AccountService.Infrastructure.Models.ApiKey MapToInfra(ApiKey apiKey) {
        return new AccountService.Infrastructure.Models.ApiKey {
            Id = apiKey.Id,
            AccountId = apiKey.AccountId,
            HashedKey = apiKey.HashedKey,
            CreatedAt = apiKey.CreatedAt,
            IsActive = apiKey.IsActive
        };
    }

    public async Task<ApiKey?> GetByHashedKeyAsync(string hashedKey) {
        var infraApiKey = await DbContext.ApiKeys
            .FirstOrDefaultAsync(k => k.HashedKey == hashedKey);
        return infraApiKey == null ? null : MapToDomain(infraApiKey);
    }

    public async Task<ApiKey?> GetByAccountIdAsync(Guid accountId) {
        var infraApiKey = await DbContext.ApiKeys
            .FirstOrDefaultAsync(k => k.AccountId == accountId);
        return infraApiKey == null ? null : MapToDomain(infraApiKey);
    }

    public async Task<IEnumerable<ApiKey>> GetAllByAccountIdAsync(Guid accountId) {
        var infraApiKeys = await DbContext.ApiKeys
            .Where(k => k.AccountId == accountId)
            .ToListAsync();
        return infraApiKeys.Select(MapToDomain).ToList();
    }
}


