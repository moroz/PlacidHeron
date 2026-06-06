using System.Linq.Expressions;
using HomeoSapiens.Data;
using HomeoSapiens.Models.Dtos;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class PlaylistRepository(AppDbContext dbContext)
{
    public async Task<ICollection<PlaylistIndexDto>> ListPlaylists()
    {
        return await dbContext.Playlists.OrderByDescending(p => p.Id).Select(p => new PlaylistIndexDto
        {
            Id = p.Id,
            Slug = p.Slug,
            TitleEn = p.TitleEn,
            TitlePl = p.TitlePl,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            VideoCount = p.Videos!.Count,
            TotalDuration = p.Videos!.Sum(video => video.DurationSeconds) ?? 0
        }).ToListAsync();
    }

    public Task<Playlist?> GetPlaylistById(Guid id) => GetPlaylist(p => p.Id == id);

    public Task<Playlist?> GetPlaylistBySlug(string slug) => GetPlaylist(p => p.Slug == slug);

    private async Task<Playlist?> GetPlaylist(Expression<Func<Playlist, bool>> predicate)
    {
        var playlist = await dbContext
            .Playlists
            .Include(p => p.PlaylistVideos!.OrderBy(j => j.Position))
            .ThenInclude(j => j.Video)
            .FirstOrDefaultAsync(predicate);

        playlist?.Videos = playlist.PlaylistVideos!.Select(j => j.Video!).ToList();

        return playlist;
    }
}