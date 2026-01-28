namespace AccountService.Api.Endpoints.Accounts;

public static class CreateAccount {
    public static async Task<IResult> Handle() {
        //CreateAccountRequest request,
        //IAccountRepository repository,
        //TimeProvider time) {
        //var account = Account.Create(
        //    request.Name,
        //    time.GetUtcNow());

        //await repository.AddAsync(account);

        //return Results.Created(
        //    $"/accounts/{account.Id}",
        //    new { account.Id });

        return Results.Ok();
    }
}