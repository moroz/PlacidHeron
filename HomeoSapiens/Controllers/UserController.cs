using Microsoft.AspNetCore.Mvc;

namespace HomeoSapiens.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok(new
        {
            Data = "OK"
        });
    }
}