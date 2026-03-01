using AccountService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure;

public class AccountDbContext(DbContextOptions<AccountDbContext> options) : DbContext(options) {
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Account>(eb => {
            eb.HasKey(a => a.Id);
            eb.Property(a => a.Name).IsRequired().HasMaxLength(100);
            eb.Property(a => a.CreatedAt).IsRequired();
            eb.HasOne(a => a.ApiKey)
              .WithOne()
              .HasForeignKey<ApiKey>(k => k.AccountId)
              .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ApiKey>(eb => {
            eb.HasKey(k => k.Id);
            eb.Property(k => k.HashedKey).IsRequired();
            eb.Property(k => k.CreatedAt).IsRequired();
            eb.Property(k => k.IsActive).IsRequired();
            eb.HasIndex(k => k.HashedKey).IsUnique();
            eb.HasIndex(k => k.AccountId);
        });
    }
}
