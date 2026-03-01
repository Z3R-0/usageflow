namespace AccountService.Infrastructure.Models;

public class ApiKey {
    public required Guid Id { get; set; }
    public required Guid AccountId { get; set; }
    public required string HashedKey { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required bool IsActive { get; set; }

    // Navigation property
    public Account? Account { get; set; }
}
