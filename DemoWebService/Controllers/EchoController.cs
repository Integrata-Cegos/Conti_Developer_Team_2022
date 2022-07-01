using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("api")]
public class EchoController : ControllerBase 
{
    [HttpGet("ping")]
    public String ping()
    {
        Console.WriteLine("######## called ping");
        return "pong";
    }
     [HttpGet("echo/{message}")]
    public String echo([FromRoute] String message)
    {
        Console.WriteLine("######## called echo with message " + message);
        return message;
    }

}