using HomeoSapiens.Entities;
using HomeoSapiens.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace HomeoSapiens.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(UserRole.Regular);
    }
}