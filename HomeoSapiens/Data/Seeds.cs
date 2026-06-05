using System.Transactions;
using HomeoSapiens.Models.Entities;
using HomeoSapiens.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HomeoSapiens.Data;

public static class Seeds
{
    public static async Task Run(AppDbContext dbContext)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        await dbContext.UpsertRange(new User
            {
                Email = "karol@moroz.dev",
                FamilyName = "Moroz",
                GivenName = "Karol",
                Role = UserRole.Admin
            })
            .On(u => u.Email)
            .NoUpdate()
            .RunAsync();

        await dbContext.UpsertRange(
                new Event
                {
                    TitleEn = "Sample Event",
                    TitlePl = "Sample Event",
                    Slug = "sample-event",
                    StartsAt = DateTime.Today.ToUniversalTime().AddDays(3).AddHours(10),
                    EndsAt = DateTime.Today.ToUniversalTime().AddDays(3).AddHours(12),
                    DescriptionEn = "Description",
                    DescriptionPl = "Description"
                })
            .On(u => u.Slug)
            .NoUpdate()
            .RunAsync();

        scope.Complete();
    }
}