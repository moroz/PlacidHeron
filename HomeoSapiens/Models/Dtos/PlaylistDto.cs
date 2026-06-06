namespace HomeoSapiens.Models.Dtos;

public class PlaylistDto
{
    public required Guid Id { get; set; }
    public required string Slug { get; set; }
    public required string TitleEn { get; set; }
    public required string TitlePl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int VideoCount { get; set; }
    public int TotalDuration { get; set; }
}