using HomeoSapiens.Data;
using HomeoSapiens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Repositories;

public class UserRepository(AppDbContext dbContext)
{
    public async Task<ICollection<User>> ListUsers()
    {
        return await dbContext.Users.OrderBy(u => u.Id).ToListAsync();
    }
}