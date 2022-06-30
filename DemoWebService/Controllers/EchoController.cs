namespace DemoWebService.Controllers;

[ApiController]
[Route("api")]
public class EchoController : ControllerBase
{
    [HttpGet]
    public string Ping()
    {
        return "Pong";
    }

    [HttpGet("echo/{m}")]
    public string Echo([FromRoute] string message)
    {
        return message;
    }
}
