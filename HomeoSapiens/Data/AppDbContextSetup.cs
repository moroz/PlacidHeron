using HomeoSapiens.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace HomeoSapiens.Data;

public static class AppDbContextSetup
{
    public static IServiceCollection AddAppDb(this IServiceCollection s, IConfiguration cfg)
    {
        return s.AddDbContext<AppDbContext>(optionsBuilder =>
            optionsBuilder
                .UseNpgsql(cfg.GetConnectionString("Default"), npgsql =>
                    npgsql.MapEnum<UserRole>("user_role"))
                .UseSnakeCaseNamingConvention());
    }
}