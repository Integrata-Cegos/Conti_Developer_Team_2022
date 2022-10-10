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

    [HttpGet("path/count/{ItemCategory}")]
    [Produces("text/plain")]
    public ActionResult<String> GetNumberOfItemsFor([FromRoute(Name="ItemCategory")] string category)
    {
        return _storeService.GetNumberOfItemsFor(category).ToString();
    }

    [HttpGet("path/categories")]
    [Produces("application/json")]
    public ActionResult<List<string>> GetCategories()
    {
        return _storeService.GetCategories();
    }

[HttpPost]
    public ActionResult SetStock([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromHeader(Name="stock")] int stock){
        _storeService.SetStock(category, item, stock);
        return new EmptyResult();
    }

}
