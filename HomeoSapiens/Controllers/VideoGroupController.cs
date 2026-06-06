using HomeoSapiens.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class VideoGroupController(VideoGroupRepository videoGroupRepository) : Controller
{
    [HttpGet("/api/v1/playlists")]
    public async Task<IActionResult> Index()
    {
        var videoGroups = await videoGroupRepository.ListVideoGroups();

        return Ok(new
        {
            Data = videoGroups
        });
    }

    [HttpGet("/api/v1/playlists/{id}")]
    public async Task<IActionResult> Show(Guid id)
    {
        var videoGroup = await videoGroupRepository.GetVideoGroupById(id);

        return Ok(new
        {
            Data = videoGroup,
        });
    }
}