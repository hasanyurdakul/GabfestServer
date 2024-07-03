using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;

namespace Gabfest.API;

[Route("api/[controller]")]
[ApiController]
public class HubController : ControllerBase
{
    private readonly ISignalRConnection _signalRConnection;

    public HubController(ISignalRConnection signalRConnection)
    {
        _signalRConnection = signalRConnection;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string message)
    {
        var connect = _signalRConnection.StartConnection();
        await connect.InvokeAsync("SendMessageToAll", "Admin", message);
        return Ok();
    }
}
