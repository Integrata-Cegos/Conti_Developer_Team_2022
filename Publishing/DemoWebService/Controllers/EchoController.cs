using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("api")]
public class EchoController : ControllerBase 
{
    [HttpGet("ping")]
    public string ping()
    {
        return "pong";
    }

    [HttpGet("echo/{m}")]
    public string echo(string message)
    {
        return message;
    }
}