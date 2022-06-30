using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("API")]
public class EchoController : ControllerBase 
{ 

    [HttpGet]
    public String ping()
    {
        Console.WriteLine("Aufruf der Ping Funktioncalled ping");
        return "pong";
    }

    [HttpGet("echo/{message}")]

    public String echo([FromRoute] String message)
    { 
        Console.WriteLine(" Echo mit Message");
        return message;
    }
}