using Microsoft.AspNetCore.Mvc;
using Javacream.Store.API;
namespace Javacream.Store.Rest.Controllers;

[ApiController]
[Route("api/store")]
public class StoreWebServiceController : ControllerBase
{
    private readonly IStoreService _storeService; 
    public StoreWebServiceController(IStoreService storeService)
    {
        _storeService = storeService;
    }
    [HttpGet("path/{ItemCategory}/{ItemId}")]
    [Produces("text/plain")]
    public ActionResult<String> GetStock([FromRoute(Name="ItemCategory")] string category, [FromRoute(Name="ItemId")]string item)
    {
        return _storeService.GetStock(category, item).ToString();
    }
[HttpPost]
    public ActionResult SetStock([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromHeader(Name="stock")] int stock){
        _storeService.SetStock(category, item, stock);
        return new EmptyResult();
    }

}
