using Microsoft.EntityFrameworkCore;
using Shared.Repository.Models;

namespace Shared.Repository;

/// <summary>
/// Generic base repository providing common CRUD operations for domain entities.
/// Implementations should inherit from this class and their specific IRepository interface
/// </summary>
public abstract class BaseRepository<TDomain, TInfra, TContext>(TContext dbContext)
    where TInfra : class, IBaseEntity<Guid>
    where TContext : DbContext
{
    protected readonly TContext DbContext = dbContext;

    protected abstract DbSet<TInfra> GetDbSet();

    protected abstract TDomain MapToDomain(TInfra infraEntity);

    protected abstract TInfra MapToInfra(TDomain domainEntity);

    public virtual async Task<TDomain?> GetByIdAsync(Guid id)
    {
        var infraEntity = await GetDbSet().FindAsync(id);
        return infraEntity == null ? default : MapToDomain(infraEntity);
    }

    public virtual async Task<TDomain> CreateAsync(TDomain domainEntity)
    {
        var infraEntity = MapToInfra(domainEntity);
        GetDbSet().Add(infraEntity);
        await DbContext.SaveChangesAsync();
        return domainEntity;
    }

    public virtual async Task<TDomain> UpdateAsync(TDomain domainEntity)
    {
        var infraEntity = MapToInfra(domainEntity);
        GetDbSet().Update(infraEntity);
        await DbContext.SaveChangesAsync();
        return domainEntity;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var infraEntity = await GetDbSet().FindAsync(id)
            ?? throw new KeyNotFoundException($"{typeof(TInfra).Name} with id {id} not found");

        GetDbSet().Remove(infraEntity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        var infraEntities = await GetDbSet().ToListAsync();
        return infraEntities.Select(MapToDomain).ToList();
    }
}


