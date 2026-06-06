using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Models.Entities;

[Index(nameof(VideoGroupId), nameof(Position), IsUnique = true)]
[Index(nameof(VideoGroupId), nameof(VideoId), IsUnique = true)]
public class VideoGroupVideo
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid VideoId { get; set; }
    public Video? Video { get; set; }

    public Guid VideoGroupId { get; set; }
    public VideoGroup? VideoGroup { get; set; }

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}