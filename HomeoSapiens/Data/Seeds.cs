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

        const string modiSeminar1 = "019da123-449c-7038-aae3-303255746cc4";
        const string asherWebinar = "019daf95-04e3-7615-99fc-ba808d1dd589";
        const string modiWebinar = "019daf95-d855-748d-93a9-4c17d0536f2f";
        const string modiSeminar2 = "019daf9b-7234-71bb-be93-f9f965d56ac6";
        const string jeggelsWebinar = "019dc005-f4a8-76fb-afdd-2e5caff8fb5a";

        Playlist Group(string id, string slug, string titleEn, string titlePl) => new()
        {
            Id = Guid.Parse(id), Slug = slug, TitleEn = titleEn, TitlePl = titlePl
        };

        var playlists = new[]
        {
            Group(modiSeminar1, "dr-sanjay-modi-to-perfect-the-art-of-homeopathy",
                "Dr Sanjay Modi: To Perfect the Art of Homeopathy",
                "Udoskonalić kunszt homeopatyczny: Seminarium z drem Sanjayem Modim"),
            Group(asherWebinar, "dr-asher-shaikh-webinar",
                "Dr Asher Shaikh Webinar",
                "Webinarium z drem Asherem Shaikh"),
            Group(modiWebinar, "dr-sanjay-modi-webinar",
                "Dr Sanjay Modi Webinar",
                "Webinarium z drem Sanjayem Modim"),
            Group(modiSeminar2, "dr-sanjay-modi-to-perfect-the-art-of-homeopathy-2",
                "Dr Sanjay Modi: To Perfect the Art of Homeopathy 2",
                "Udoskonalić kunszt homeopatyczny 2: Seminarium z drem Sanjayem Modim"),
            Group(jeggelsWebinar, "dr-herman-jeggels-webinar",
                "Dr Herman Jeggels Webinar",
                "Webinarium z drem Hermanem Jeggelsem")
        };

        await dbContext.UpsertRange(playlists)
            .On(g => g.Id)
            .NoUpdate()
            .RunAsync();

        const string perfect1Day1 = "019dbfeb-e6f2-7521-b990-119d82b8665f";
        const string perfect1Day2 = "019dbfeb-e5ec-73ae-881a-d76c8582644e";
        const string perfect2Day1Part1 = "019a8668-bb4f-7c9c-b9b8-3f274de96566";
        const string perfect2Day1Part2 = "019a8ba5-fe29-7af8-bf54-b8d96af38461";
        const string perfect2Day2Part1 = "019e26f5-94ff-738f-b892-f25c3ceaa231";
        const string perfect2Day2Part2 = "019e26f8-414c-7032-b627-77d1107b558d";
        const string perfect2Day2Part3 = "019e26f8-a4d3-729b-872e-9d66242969ef";
        const string dutifulRemedies = "019dbfeb-e512-740f-80ea-d8c30a99fa5b";
        const string movingOn = "019dbfeb-e43a-7324-bb52-65457afc331b";
        const string cardiacCases = "019dbfec-770a-702f-aa5c-e2431a930395";

        Video Vid(string id, string slug, string titleEn, string titlePl, int durationSeconds,
            string thumbnailEnId, string thumbnailPlId) => new()
        {
            Id = Guid.Parse(id), Slug = slug, TitleEn = titleEn, TitlePl = titlePl,
            DurationSeconds = durationSeconds,
            ThumbnailEnId = Guid.Parse(thumbnailEnId), ThumbnailPlId = Guid.Parse(thumbnailPlId)
        };

        var videos = new[]
        {
            Vid(perfect1Day1, "to-perfect-the-art-of-homeopathy-day-1",
                "To Perfect the Art of Homeopathy: Day 1",
                "Udoskonalić kunszt homeopatyczny: Dzień 1",
                18107, "019de856-ec6e-76f6-a5cc-10508960adc8", "019de856-ebc5-79ee-ab25-a7482adebcb0"),
            Vid(perfect1Day2, "to-perfect-the-art-of-homeopathy-day-2",
                "To Perfect the Art of Homeopathy: Day 2",
                "Udoskonalić kunszt homeopatyczny: Dzień 2",
                18470, "019de856-ea73-7a5b-9798-a0b68193ebe5", "019de856-eb1b-779d-85a1-95e040bfc733"),
            Vid(perfect2Day1Part1, "to-perfect-the-art-of-homeopathy-2-day-1-part-1",
                "To Perfect the Art of Homeopathy 2: Day 1, Part 1",
                "Udoskonalić kunszt homeopatyczny 2: Dzień 1, Część 1",
                8344, "019de856-e5a2-7edb-9bba-215d32de9250", "019de856-e4bd-799d-a689-8d4d5cf7370b"),
            Vid(perfect2Day1Part2, "to-perfect-the-art-of-homeopathy-2-day-1-part-2",
                "To Perfect the Art of Homeopathy 2: Day 1, Part 2",
                "Udoskonalić kunszt homeopatyczny 2: Dzień 1, Część 2",
                7097, "019de856-e6ef-73f3-88f6-9b1772fdf073", "019de856-e650-7d54-a6ba-ff70c8e812fb"),
            Vid(dutifulRemedies, "sanjay-modi-dutiful-remedies",
                "Dutiful Remedies: Differential Diagnosis",
                "Sumienne leki: Diagnostyka różnicowa",
                4943, "019de856-e903-7939-ad2b-8a3f0abc43b1", "019de856-e9bb-7ad6-81ea-04c12e24768b"),
            Vid(movingOn, "asher-shaikh-what-prevents-me-from-moving-on",
                "What prevents me from moving on?",
                "What prevents me from moving on?",
                8389, "019de856-e865-79a5-829a-45cad21e4e34", "019de856-e799-70b2-85a6-0c36770b45e3"),
            Vid(cardiacCases, "jeggels-critical-cardiac-cases",
                "A Series of Critical Cardiac Cases",
                "Seria krytycznych przypadków kardiologicznych",
                5523, "019de856-ed0c-7bb5-931c-4061cf50e25d", "019de856-edd2-7494-9d7e-0f69f3629301"),
            Vid(perfect2Day2Part1, "to-perfect-the-art-of-homeopathy-2-day-2-part-1",
                "To Perfect the Art of Homeopathy 2: Day 2, Part 1",
                "Udoskonalić kunszt homeopatyczny 2: Dzień 2, Część 1",
                5898, "019e26ff-6629-7d07-99c8-c15382ea8f4b", "019e26ff-66bf-707d-937e-6c58b9f414c7"),
            Vid(perfect2Day2Part2, "to-perfect-the-art-of-homeopathy-2-day-2-part-2",
                "To Perfect the Art of Homeopathy 2: Day 2, Part 2",
                "Udoskonalić kunszt homeopatyczny 2: Dzień 2, Część 2",
                4078, "019e26ff-6734-7079-a83a-2d1e9233a70e", "019e26ff-67a0-7338-a6d5-af6cd7b44b24"),
            Vid(perfect2Day2Part3, "to-perfect-the-art-of-homeopathy-2-day-2-part-3",
                "To Perfect the Art of Homeopathy 2: Day 2, Part 3",
                "Udoskonalić kunszt homeopatyczny 2: Dzień 2, Część 3",
                5637, "019e26ff-6810-7ef8-95ed-4e2d8368ad32", "019e26ff-688a-7a7b-9b65-067dfc7ef81b")
        };

        await dbContext.UpsertRange(videos)
            .On(v => v.Id)
            .NoUpdate()
            .RunAsync();

        const string hls = "application/vnd.apple.mpegurl";
        const string mp4 = "video/mp4";
        const string webm = "video/webm";

        VideoSource Source(string id, string videoId, int position, string contentType, string? codec,
            string objectKey) => new()
        {
            Id = Guid.Parse(id), VideoId = Guid.Parse(videoId), Position = position,
            ContentType = contentType, Codec = codec, ObjectKey = objectKey
        };

        var videoSources = new[]
        {
            Source("019dc00d-97b0-743c-9146-f214dacc65f7", perfect2Day1Part1, 0, hls, null,
                $"/videos/{perfect2Day1Part1}/hls/p1_hls.m3u8"),
            Source("019a8ba6-c5ae-7f6f-becb-94b6957a52b2", perfect2Day1Part1, 1, mp4, "hev1",
                $"/videos/{perfect2Day1Part1}/hevc_1080.mp4"),
            Source("019a8ba7-d04b-77ec-92c6-f76b6ec0e7ea", perfect2Day1Part1, 2, webm, "vp9,opus",
                $"/videos/{perfect2Day1Part1}/webm_1080.webm"),
            Source("019a8bab-135e-7321-9857-f74d2dcda427", perfect2Day1Part2, 0, mp4, "hev1",
                $"/videos/{perfect2Day1Part2}/hevc_1080.mp4"),
            Source("019a8bab-bc67-76f9-bf80-902043c922e6", perfect2Day1Part2, 1, webm, "vp9,opus",
                $"/videos/{perfect2Day1Part2}/webm_1080.webm"),
            Source("019dc005-f553-7766-aaaa-b48b30707c22", perfect1Day1, 0, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{perfect1Day1}/avc1_1080.mp4"),
            Source("019dc00b-eb9d-749e-98bf-5ff4b4b76716", perfect1Day1, 1, hls, null,
                $"/videos/{perfect1Day1}/hls/index.m3u8"),
            Source("019dc005-f5f7-773f-8e4d-a73fbae12631", perfect1Day2, 0, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{perfect1Day2}/avc1_1080.mp4"),
            Source("019dc00b-ec50-7460-9633-c09016979e48", perfect1Day2, 1, hls, null,
                $"/videos/{perfect1Day2}/hls/index.m3u8"),
            Source("019dc005-f68e-73db-8700-ec654ffe675c", dutifulRemedies, 0, mp4, "avc1.64001f,mp4a.40.2",
                $"/videos/{dutifulRemedies}/avc1_720.mp4"),
            Source("019dc00b-ed09-759f-b756-3968e8e49531", dutifulRemedies, 1, hls, null,
                $"/videos/{dutifulRemedies}/hls/index.m3u8"),
            Source("019dc005-f735-765f-a735-f1c66e74e860", movingOn, 0, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{movingOn}/avc1_1080.mp4"),
            Source("019dc00b-edba-70ef-80b9-12b5fdf8f35d", movingOn, 1, hls, null,
                $"/videos/{movingOn}/hls/index.m3u8"),
            Source("019dc005-f7df-7661-8c0c-af1a4c4a8f33", cardiacCases, 0, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{cardiacCases}/avc1_1080.mp4"),
            Source("019dc00b-ee64-77ce-b15e-2e03b8c573b2", cardiacCases, 1, hls, null,
                $"/videos/{cardiacCases}/hls/index.m3u8"),
            Source("019e2750-3200-7772-8f4d-c4da489feeac", perfect2Day2Part1, 0, hls, null,
                $"/videos/{perfect2Day2Part1}/hls/index.m3u8"),
            Source("019e2728-27ba-7a90-b3f5-f0eaa8699211", perfect2Day2Part1, 1, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{perfect2Day2Part1}/avc1_1080.mp4"),
            Source("019e2756-723a-7849-b95c-b0c3f4aa0dcd", perfect2Day2Part2, 0, hls, null,
                $"/videos/{perfect2Day2Part2}/hls/index.m3u8"),
            Source("019e2728-27bd-720e-ad38-da6021029419", perfect2Day2Part2, 1, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{perfect2Day2Part2}/avc1_1080.mp4"),
            Source("019e275e-fda7-7df7-bf68-ddbc64d916c0", perfect2Day2Part3, 0, hls, null,
                $"/videos/{perfect2Day2Part3}/hls/index.m3u8"),
            Source("019e2728-27bd-77aa-90cf-f9b9e3b7ea6b", perfect2Day2Part3, 1, mp4, "avc1.640028,mp4a.40.2",
                $"/videos/{perfect2Day2Part3}/avc1_1080.mp4")
        };

        await dbContext.UpsertRange(videoSources)
            .On(s => s.Id)
            .NoUpdate()
            .RunAsync();

        PlaylistVideo GroupVideo(string id, string playlistId, string videoId, int position) => new()
        {
            Id = Guid.Parse(id), PlaylistId = Guid.Parse(playlistId), VideoId = Guid.Parse(videoId),
            Position = position
        };

        var playlistVideos = new[]
        {
            GroupVideo("019de883-cd46-7da6-a99b-9ed5f8dfe413", modiSeminar1, perfect1Day1, 0),
            GroupVideo("019de883-cd46-7f97-a00d-1d4b29a911eb", modiSeminar1, perfect1Day2, 1),
            GroupVideo("019de883-cd46-7fb7-b519-956e9979eb5a", modiSeminar2, perfect2Day1Part1, 0),
            GroupVideo("019de883-cd46-7fc8-a9a4-7711774a9b95", modiSeminar2, perfect2Day1Part2, 1),
            GroupVideo("019e26fa-b837-77bc-aae3-2c9d3f23bc61", modiSeminar2, perfect2Day2Part1, 2),
            GroupVideo("019e26fa-d10e-77f8-a289-f962d6edb83f", modiSeminar2, perfect2Day2Part2, 3),
            GroupVideo("019e26fa-e8a2-74a4-9b72-95c327210e76", modiSeminar2, perfect2Day2Part3, 4),
            GroupVideo("019de883-cd46-7fe3-b5bd-56a742f5a2fc", modiWebinar, dutifulRemedies, 0),
            GroupVideo("019de883-cd46-7ff3-ad87-df0854df1c4e", asherWebinar, movingOn, 0),
            GroupVideo("019de883-cd47-7002-9e69-c6ec4ee52c91", jeggelsWebinar, cardiacCases, 0)
        };

        await dbContext.UpsertRange(playlistVideos)
            .On(gv => gv.Id)
            .NoUpdate()
            .RunAsync();

        scope.Complete();
    }
}