namespace AccountService.Api.Extensions;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddAccountModule(
            this IServiceCollection services,
            IConfiguration config) {
        services.AddScoped<IAccountRepository, SqlAccountRepository>();
        services.AddScoped<IApiKeyService, ApiKeyService>();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
