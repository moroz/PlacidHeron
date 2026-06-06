using HomeoSapiens.Models.Entities;
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

    [HttpGet("/api/v1/playlists/{id:guid}")]
    public async Task<IActionResult> Show(Guid id) =>
        PlaylistResult(await playlistRepository.GetPlaylistById(id));

    [HttpGet("/api/v1/playlists/{slug}")]
    public async Task<IActionResult> Show(string slug) =>
        PlaylistResult(await playlistRepository.GetPlaylistBySlug(slug));

    private IActionResult PlaylistResult(Playlist? playlist) =>
        playlist is null ? NotFound() : Ok(new { Data = playlist });
}