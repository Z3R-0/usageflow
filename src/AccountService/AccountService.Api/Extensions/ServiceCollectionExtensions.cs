using AccountService.Infrastructure;
using AccountService.Repository.Implementations;
using AccountService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Api.Extensions;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddAccountModule(
            this IServiceCollection services,
            IConfiguration config) {
        // Register repositories
        services.AddScoped<IAccountRepository, SqlAccountRepository>();
        services.AddScoped<IApiKeyRepository, SqlApiKeyRepository>();

        services.AddSingleton(TimeProvider.System);
        
        // DbContext
        // Prefer environment variable if available, fallback to appsettings
        var sqlConnectionString = Environment.GetEnvironmentVariable("AccountService")
                                  ?? config.GetConnectionString("AccountService")
                                  ?? throw new NullReferenceException("No connection string configured for SQL server");
        
        services.AddDbContext<AccountDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        return services;
    }
}
