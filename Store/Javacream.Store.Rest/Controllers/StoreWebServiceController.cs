using Microsoft.AspNetCore.Mvc;

namespace Javacream.Store.Rest.Controllers;

[ApiController]
[Route("api/store")]
public class StoreWebServiceController : ControllerBase
{

    [HttpGet("{category}/{item}")]
    public String GetStock(string category, string item)
    {
        return "Stock: 42";
    }
}
