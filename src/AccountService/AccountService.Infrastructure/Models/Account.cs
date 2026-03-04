using System.ComponentModel.DataAnnotations;

namespace AccountService.Infrastructure.Models;

public class Account : IBaseEntity<Guid> {
    [Key]
    public required Guid Id { get; init; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; init; }
    
    [Required]
    public required DateTime CreatedAt { get; init; }

    // Navigation property
    public ApiKey? ApiKey { get; init; }
}
