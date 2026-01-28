using AccountService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure;

public class AccountDbContext(DbContextOptions<AccountDbContext> options) : DbContext(options) {
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Account>(eb => {
            eb.HasKey(a => a.Id);
            eb.Property(a => a.Name).IsRequired();
            eb.Property(a => a.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<ApiKey>(eb => {
            eb.HasKey(k => k.Id);
            eb.Property(k => k.HashedKey).IsRequired();
            eb.Property(k => k.CreatedAt).IsRequired();
            eb.Property(k => k.IsActive).IsRequired();
            eb.HasOne<Account>()
              .WithOne()
              .HasForeignKey<ApiKey>(k => k.AccountId)
              .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
