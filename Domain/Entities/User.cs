using Microsoft.AspNetCore.Identity;
using System;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Common.Attributes;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;

public sealed class User : IdentityUser<ulong>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public UserProfile? Profile { get; set; }
}