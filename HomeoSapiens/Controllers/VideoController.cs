using HomeoSapiens.Models.Entities;
using HomeoSapiens.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class VideoController(VideoRepository videoRepository) : Controller
{
    // GET
    [HttpGet("/api/v1/videos/{id:guid}")]
    public async Task<IActionResult> Show(Guid id)
    {
        return ShowResponse(await videoRepository.GetVideoById(id));
    }

    [HttpGet("/api/v1/videos/{slug}")]
    public async Task<IActionResult> Show(string slug)
    {
        return ShowResponse(await videoRepository.GetVideoBySlug(slug));
    }

    private IActionResult ShowResponse(Video? video)
    {
        return video is null
            ? NotFound()
            : Ok(new
            {
                Data = video
            });
    }
}