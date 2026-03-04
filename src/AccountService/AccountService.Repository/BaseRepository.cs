using AccountService.Infrastructure;
using AccountService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository;

public abstract class BaseRepository<TDomain, TInfra>(AccountDbContext dbContext)
    where TInfra : class, IBaseEntity<Guid>
{
    protected readonly AccountDbContext DbContext = dbContext;

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


