namespace Conti.Tom.Publishing.Store.REST_API.Controllers;


[ApiController]
[Route("[controller]")]
public class StoreServiceController : ControllerBase
{
    IStoreService _storeService;

    public StoreServiceController(IStoreService storeService)
    {
        _storeService = storeService;   
    }

    [HttpGet("GetStock/{category}/{itemid}")]
    public int GetStock([FromRoute(Name ="category")]string category, [FromRoute(Name = "itemid")] string item)
    {
        return _storeService.GetStock(category, item);
    }

    [HttpPost("SetStock/{category}/{item}/{stock}")]
    public void SetStock(string category, string item, int stock)
    {
        _storeService.SetStock(category, item, stock);
    }
}
