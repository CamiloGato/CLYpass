using Microsoft.AspNetCore.Mvc;

namespace CLYPassBackend.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("¡Bienvenido a CLYPass Backend!");
    }
}