using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Models.Entities;

[Index(nameof(VideoId), nameof(Position), IsUnique = true)]
public class VideoSource
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [JsonIgnore] public Guid VideoId { get; set; }
    [JsonIgnore] public Video? Video { get; set; }
    [JsonIgnore] public int Position { get; set; }

    public required string ContentType { get; set; }
    public string? Codec { get; set; }
    public required string ObjectKey { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}