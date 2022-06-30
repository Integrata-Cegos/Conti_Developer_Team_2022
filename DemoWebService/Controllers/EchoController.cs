using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase 
{
    [HttpGet]
    public String ping()
    {
        Console.WriteLine("Called ping");
        return "pong";
    }
}