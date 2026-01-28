using System;
using System.Collections.Generic;
using System.Text;

namespace AccountService.Infrastructure.Models; 

public class Account {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
}
