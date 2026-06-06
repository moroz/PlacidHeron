using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Models.Entities;

[Index(nameof(PlaylistId), nameof(Position), IsUnique = true)]
[Index(nameof(PlaylistId), nameof(VideoId), IsUnique = true)]
public class PlaylistVideo
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid VideoId { get; set; }
    public Video? Video { get; set; }

    public Guid PlaylistId { get; set; }
    public Playlist? Playlist { get; set; }

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}