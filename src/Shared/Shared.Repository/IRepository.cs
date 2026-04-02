namespace Shared.Repository;

/// <summary>
/// Generic repository interface that defines base CRUD operations.
/// Implementations should inherit from BaseRepository and implement this interface.
/// </summary>
/// <typeparam name="TDomain">The domain model type</typeparam>
public interface IRepository<TDomain>
{
    Task<TDomain?> GetByIdAsync(Guid id);
    Task<TDomain> CreateAsync(TDomain domainEntity);
    Task<TDomain> UpdateAsync(TDomain domainEntity);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<TDomain>> GetAllAsync();
}

