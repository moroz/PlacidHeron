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

        Asset File(string id, string key, string orig) => new()
        {
            Id = Guid.Parse(id), ObjectKey = key, OriginalFilename = orig, Scaled = false
        };

        Asset Placeholder(string id) => new() { Id = Guid.Parse(id), Scaled = true };

        var assets = new[]
        {
            File("0199c2f2-528b-7e88-96e3-5e5088333a8b", "cm7uqj3q500mglz8z2dqy8sdz.webp", "cm7uqj3q500mglz8z2dqy8sdz.webp"),
            File("019b0c7c-c3c4-71c3-a630-7b33a847ca2a", "019b0c7c-c3c4-71c3-a630-7b33a847ca2a.jpg", "019b0c7c-c3c4-71c3-a630-7b33a847ca2a.jpg"),
            File("019beef9-ad4c-736f-9bb0-965b59ca21ae", "019beef9-ad4c-736f-9bb0-965b59ca21ae.png", "drasher.png"),
            Placeholder("019de856-e5a2-7edb-9bba-215d32de9250"),
            Placeholder("019de856-e4bd-799d-a689-8d4d5cf7370b"),
            Placeholder("019de856-e6ef-73f3-88f6-9b1772fdf073"),
            Placeholder("019de856-e650-7d54-a6ba-ff70c8e812fb"),
            Placeholder("019de856-e865-79a5-829a-45cad21e4e34"),
            Placeholder("019de856-e799-70b2-85a6-0c36770b45e3"),
            Placeholder("019de856-e903-7939-ad2b-8a3f0abc43b1"),
            Placeholder("019de856-e9bb-7ad6-81ea-04c12e24768b"),
            Placeholder("019de856-ea73-7a5b-9798-a0b68193ebe5"),
            Placeholder("019de856-eb1b-779d-85a1-95e040bfc733"),
            Placeholder("019de856-ec6e-76f6-a5cc-10508960adc8"),
            Placeholder("019de856-ebc5-79ee-ab25-a7482adebcb0"),
            Placeholder("019de856-ed0c-7bb5-931c-4061cf50e25d"),
            Placeholder("019de856-edd2-7494-9d7e-0f69f3629301"),
            Placeholder("019e26ff-6629-7d07-99c8-c15382ea8f4b"),
            Placeholder("019e26ff-66bf-707d-937e-6c58b9f414c7"),
            Placeholder("019e26ff-6734-7079-a83a-2d1e9233a70e"),
            Placeholder("019e26ff-67a0-7338-a6d5-af6cd7b44b24"),
            Placeholder("019e26ff-6810-7ef8-95ed-4e2d8368ad32"),
            Placeholder("019e26ff-688a-7a7b-9b65-067dfc7ef81b")
        };

        await dbContext.UpsertRange(assets)
            .On(a => a.Id)
            .NoUpdate()
            .RunAsync();

        scope.Complete();
    }
}