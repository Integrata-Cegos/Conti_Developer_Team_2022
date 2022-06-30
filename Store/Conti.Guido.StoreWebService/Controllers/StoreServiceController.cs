using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("API/Store")]
public class EchoController : ControllerBase 
{ 

    [HttpGet("{category}/{item}")]
    public String GetStock(string category, string item)
    {
        return "Stock ; 13";
    }

}