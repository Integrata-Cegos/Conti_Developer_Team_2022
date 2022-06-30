using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase 
{
    [HttpGet]
    public string ping()
    {
        Console.WriteLine("# called Ping");
        return "pong";
    }
    [HttpGet("echo/{message}")]
    public String echo([FromRoute] String message){
        Console.WriteLine("# called echo with message " + message);
        return message;
    }


}