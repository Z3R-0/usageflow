namespace AccountService.Api.Endpoints.Accounts;

public static class AccountsEndpoints {
    public static IEndpointRouteBuilder MapAccountsEndpoints(
        this IEndpointRouteBuilder app) {
        var group = app.MapGroup("/accounts")
                       .WithTags("Accounts");

        group.MapPost("/", CreateAccount.Handle);

        return app;
    }
}
