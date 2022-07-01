using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("api")]
public class StoreController : ControllerBase
{
    [HttpGet("ping")]
    public String ping()
    {
        return "pong";
    }
    [HttpGet("Store/{message}")]
    public String echo([FromRoute] String message)
    {
        Console.WriteLine("### called echo with message " + message);
        return message;
    }
}