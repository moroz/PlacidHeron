using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Models.Entities;

[Index(nameof(Slug), IsUnique = true)]
public class Event
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [Column(TypeName = "citext")] public required string Slug { get; set; }

    [MaxLength(255)] public required string TitlePl { get; set; }
    [MaxLength(255)] public required string TitleEn { get; set; }

    public required string DescriptionEn { get; set; }
    public required string DescriptionPl { get; set; }

    public required DateTime StartsAt { get; set; }
    public required DateTime EndsAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}