using HomeoSapiens.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class EventController(EventRepository eventRepository) : Controller

{
    [HttpGet("/api/v1/events")]
    public async Task<IActionResult> Index()
    {
        var events = await eventRepository.ListEvents();

        return Ok(new
        {
            Data = events
        });
    }
}