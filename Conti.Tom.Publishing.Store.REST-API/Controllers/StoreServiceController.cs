namespace Conti.Tom.Publishing.Store.REST_API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreServiceController : ControllerBase
{
    [HttpGet]
    [Route("GetStock/{category}")]
    public int GetStock(string category)
    {
        return 1;
    }

    [HttpPost]
    [Route("SetStock/{category}")]
    public void SetStock(string category)
    {
        return;
    }
}
