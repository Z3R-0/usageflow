using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Infrastructure.Models;

public class ApiKey : IBaseEntity<Guid> {
    [Key]
    public required Guid Id { get; init; }
    
    [Required]
    [ForeignKey(nameof(Account))]
    public required Guid AccountId { get; init; }
    
    [Required]
    [MaxLength(36)]
    public required string HashedKey { get; init; }
    
    [Required]
    public required DateTime CreatedAt { get; init; }
    
    [Required]
    public required bool IsActive { get; init; }

    // Navigation property
    public Account? Account { get; init; }
}
