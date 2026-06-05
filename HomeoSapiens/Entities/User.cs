using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key] public Guid Id { get; set; }

    [DataType("citext")] public required string Email { get; set; }

    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}