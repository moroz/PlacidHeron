using HomeoSapiens.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class PlaylistController(PlaylistRepository playlistRepository) : Controller
{
    [HttpGet("/api/v1/playlists")]
    public async Task<IActionResult> Index()
    {
        var playlists = await playlistRepository.ListPlaylists();

        return Ok(new
        {
            Data = playlists
        });
    }

    [HttpGet("/api/v1/playlists/{id}")]
    public async Task<IActionResult> Show(Guid id)
    {
        var playlist = await playlistRepository.GetPlaylistById(id);

        if (playlist is null) return NotFound();

        return Ok(new
        {
            Data = playlist
        });
    }
}