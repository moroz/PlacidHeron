using System.Transactions;
using HomeoSapiens.Entities;
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
                Id = Guid.CreateVersion7(),
                Email = "karol@moroz.dev",
                FamilyName = "Moroz",
                GivenName = "Karol",
                Role = UserRole.Admin
            })
            .On(u => u.Email)
            .NoUpdate()
            .RunAsync();

        scope.Complete();
    }
}