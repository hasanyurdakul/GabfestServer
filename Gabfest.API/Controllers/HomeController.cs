using Microsoft.AspNetCore.Mvc;

namespace Gabfest.API;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : Controller
{
    [HttpGet]
    public string Get()
    {
        return "Hello from Gabfest API";
    }

}
