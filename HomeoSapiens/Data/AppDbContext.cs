using HomeoSapiens.Models.Entities;
using HomeoSapiens.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<VideoGroup> VideoGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(UserRole.Regular);

        modelBuilder.Entity<Event>()
            .ToTable(t => { t.HasCheckConstraint("end_time_must_be_after_start_time", "(ends_at > starts_at)"); });
    }
}