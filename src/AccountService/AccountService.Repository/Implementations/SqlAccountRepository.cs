using AccountService.Domain;
using AccountService.Infrastructure;
using AccountService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository.Implementations;

public class SqlAccountRepository(AccountDbContext dbContext)
    : BaseRepository<Account, AccountService.Infrastructure.Models.Account>(dbContext), IAccountRepository
{
    protected override DbSet<AccountService.Infrastructure.Models.Account> GetDbSet() {
        return DbContext.Accounts;
    }

    protected override Account MapToDomain(AccountService.Infrastructure.Models.Account infraAccount) {
        return new Account {
            Id = infraAccount.Id,
            Name = infraAccount.Name,
            CreatedAt = infraAccount.CreatedAt
        };
    }

    protected override AccountService.Infrastructure.Models.Account MapToInfra(Account account) {
        return new AccountService.Infrastructure.Models.Account {
            Id = account.Id,
            Name = account.Name,
            CreatedAt = account.CreatedAt
        };
    }
}


