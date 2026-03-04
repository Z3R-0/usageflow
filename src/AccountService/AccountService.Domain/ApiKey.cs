namespace AccountService.Domain;

public class ApiKey {
    public required Guid Id { get; init; }
    public required Guid AccountId { get; init; }
    public required string HashedKey { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required bool IsActive { get; init; }
}

