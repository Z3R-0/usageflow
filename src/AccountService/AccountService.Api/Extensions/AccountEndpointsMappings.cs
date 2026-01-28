using AccountService.Api.Endpoints.Accounts;

namespace AccountService.Api.Extensions;

public static class AccountEndpointsMappings {
    public static IEndpointRouteBuilder MapAccountEndpoints(
        this IEndpointRouteBuilder app) {
        app.MapAccountsEndpoints();
        //app.MapApiKeyEndpoints();
        return app;
    }
}
