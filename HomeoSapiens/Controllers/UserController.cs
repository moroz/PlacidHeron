using HomeoSapiens.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class UserController(UserRepository userRepository) : Controller
{
    // GET
    [HttpGet("/api/v1/users")]
    public async Task<IActionResult> Index()
    {
        var users = await userRepository.ListUsers();

        return Ok(new
        {
            Data = users
        });
    }
}