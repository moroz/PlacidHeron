using HomeoSapiens.Data;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class EventRepository(AppDbContext dbContext)
{
    public async Task<ICollection<Event>> ListEvents()
    {
        return await dbContext.Events.OrderByDescending(e => e.StartsAt).ToListAsync();
    }
}