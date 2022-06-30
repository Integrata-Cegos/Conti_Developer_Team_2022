using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("api")]
public class EchoController : ControllerBase
{
    [HttpGet("ping")]
    public string ping()
    {
        Console.WriteLine("######### called ping");
        return "pong";
    }
    [HttpGet("echo/{message}")]
    public string echo([FromRoute] string message)
    {
        Console.WriteLine("######### called echo with message " + message);
        return message;
    }
}