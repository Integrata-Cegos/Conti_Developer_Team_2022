using Microsoft.AspNetCore.Mvc;

namespace StoreWebService.Controllers;

[ApiController]
[Route("api/store")]

public class StoreWebService : ControllerBase
{
    [HttpGet("{category}/{item}")]
    public string GetStock (string category, string item)
    {
        return "Stock: 42";
    }
}