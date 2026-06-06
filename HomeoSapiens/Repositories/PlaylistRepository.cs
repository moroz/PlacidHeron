using HomeoSapiens.Data;
using HomeoSapiens.Models.Dtos;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class PlaylistRepository(AppDbContext dbContext)
{
    public async Task<ICollection<PlaylistDto>> ListPlaylists()
    {
        return await dbContext.Playlists.OrderByDescending(v => v.Id).Select(v => new PlaylistDto
        {
            Id = v.Id,
            Slug = v.Slug,
            TitleEn = v.TitleEn,
            TitlePl = v.TitlePl,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt,
            VideoCount = v.Videos!.Count,
            TotalDuration = v.Videos!.Sum(video => video.DurationSeconds) ?? 0
        }).ToListAsync();
    }

    public async Task<Playlist?> GetPlaylistById(Guid id)
    {
        var playlist = await dbContext
            .Playlists
            .Include(v => v.PlaylistVideos!.OrderBy(j => j.Position))
            .ThenInclude(j => j.Video)
            .FirstOrDefaultAsync(v => v.Id == id);

        playlist?.Videos = playlist.PlaylistVideos!.Select(j => j.Video!).ToList();

        return playlist;
    }
}