using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HomeoSapiens.Models.Entities;

public class Video
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [Column(TypeName = "citext")] public required string Slug { get; set; }

    public required string TitleEn { get; set; }
    public required string TitlePl { get; set; }

    public int? DurationSeconds { get; set; }

    public Guid? ThumbnailPlId { get; set; }
    public Guid? ThumbnailEnId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Asset? ThumbnailPl { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Asset? ThumbnailEn { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [JsonIgnore] public List<PlaylistVideo>? PlaylistVideos { get; set; }

    public List<VideoSource>? VideoSources { get; set; }
}