using HomeoSapiens.Data;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class VideoGroupRepository(AppDbContext dbContext)
{
    public async Task<ICollection<VideoGroup>> ListVideoGroups()
    {
        return await dbContext.VideoGroups.OrderByDescending(v => v.Id).ToListAsync();
    }

    public async Task<VideoGroup?> GetVideoGroupById(Guid id)
    {
        return await dbContext.VideoGroups.Include(v => v.Videos).FirstOrDefaultAsync(v => v.Id == id);
    }
}