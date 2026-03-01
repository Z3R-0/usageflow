namespace AccountService.Api.Endpoints.Accounts;

public static class AccountsEndpoints {
    public static IEndpointRouteBuilder MapAccountsEndpoints(
        this IEndpointRouteBuilder app) {
        var group = app.MapGroup("/accounts")
                       .WithTags("Accounts");

        group.MapPost("/create", CreateAccount.Handle);

        return app;
    }
}
