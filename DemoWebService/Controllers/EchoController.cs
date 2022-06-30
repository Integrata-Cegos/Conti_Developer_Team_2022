namespace DemoWebService.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase
{
    [HttpGet]
    public string Ping()
    {
        return "Pong";
    }

}
