using System.Linq.Expressions;
using HomeoSapiens.Data;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class VideoRepository(AppDbContext dbContext)
{
    public Task<Video?> GetVideoById(Guid id)
    {
        return GetVideo(v => v.Id == id);
    }

    public Task<Video?> GetVideoBySlug(string slug)
    {
        return GetVideo(v => v.Slug == slug);
    }

    private async Task<Video?> GetVideo(Expression<Func<Video, bool>> predicate)
    {
        return await dbContext.Videos.Include(v => v.VideoSources!.OrderBy(s => s.Position))
            .FirstOrDefaultAsync(predicate);
    }
}