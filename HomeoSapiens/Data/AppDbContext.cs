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
    public DbSet<VideoSource> VideoSources { get; set; }
    public DbSet<VideoGroupVideo> VideoGroupsVideos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(UserRole.Regular);

        modelBuilder.Entity<Event>()
            .ToTable(t => { t.HasCheckConstraint("end_time_must_be_after_start_time", "(ends_at > starts_at)"); });

        modelBuilder.Entity<VideoSource>()
            .ToTable(t =>
            {
                t.HasCheckConstraint("video_source_position_must_be_non_neg", "position >= 0");
            });

        modelBuilder.Entity<VideoGroupVideo>()
            .ToTable(t =>
            {
                t.HasCheckConstraint("video_group_video_position_must_be_non_neg", "position >= 0");
            });
    }
}