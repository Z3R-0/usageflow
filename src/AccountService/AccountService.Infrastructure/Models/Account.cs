namespace AccountService.Infrastructure.Models;

public class Account {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }

    // Navigation property
    public ApiKey? ApiKey { get; set; }
}
