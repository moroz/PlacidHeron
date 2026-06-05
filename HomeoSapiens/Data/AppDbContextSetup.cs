using HomeoSapiens.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace HomeoSapiens.Data;

public static class AppDbContextSetup
{
    public static IServiceCollection AddAppDb(this IServiceCollection s, IConfiguration cfg)
    {
        var dsb = new NpgsqlDataSourceBuilder(cfg.GetConnectionString("Default"));

        dsb.MapEnum<UserRole>("user_role");

        return s.AddDbContext<AppDbContext>(optionsBuilder =>
            optionsBuilder
                .UseNpgsql(dsb.Build())
                .UseSnakeCaseNamingConvention());
    }
}