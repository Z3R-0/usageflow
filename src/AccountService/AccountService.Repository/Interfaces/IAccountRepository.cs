using AccountService.Domain;

namespace AccountService.Repository.Interfaces;

public interface IAccountRepository {
    Task<Account?> GetByIdAsync(Guid id);
    Task<Account> CreateAsync(Account account);
    Task<Account> UpdateAsync(Account account);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Account>> GetAllAsync();
}

