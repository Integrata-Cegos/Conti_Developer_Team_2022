using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase 
{
    [HttpGet]
    public string ping()
    {
        return "pong";
    }
}