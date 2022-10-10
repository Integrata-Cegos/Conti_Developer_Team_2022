using Microsoft.AspNetCore.Mvc;
using Conti.AB.Store.API;

namespace Conti.AB.Rest.Controllers;

[ApiController]
[Route("api/store")]

public class StoreWebServiceController : ControllerBase
{
    private readonly IStoreService _storeService;

    public StoreWebServiceController (IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("path/{ItemCategory}/{ItemId}")]
    [Produces("text/plain")]
    public ActionResult<String> GetStock([FromRoute(Name="ItemCategory")] string category, [FromRoute(Name="ItemId")] string item)
    {
        return _storeService.GetStock(category, item).ToString();
    }

    [HttpDelete("path/{ItemCategory}/{ItemId}")]
    public void DeleteItem([FromRoute(Name="ItemCategory")] string category, [FromRoute(Name="ItemId")] string item)
    {
        _storeService.DeleteItem(category, item);
    }

    [HttpDelete("path/{ItemCategory}")]
    public void DeleteCategory([FromRoute(Name="ItemCategory")] string category)
    {
        _storeService.DeleteCategory(category);
    }

    [HttpGet("path/count/{ItemCategory}")]
    [Produces("application/json")]
    public ActionResult<string> GetNumberOfItemsFor ([FromRoute(Name="ItemCategory")] string category)
    {
        return _storeService.GetNumberOfItemsFor(category).ToString();
    }

    [HttpGet("path/categories")]
    [Produces("application/json")]
    public ActionResult<List<string>> GetCategories()
    {
        return _storeService.GetCategories();
    }

    [HttpGet("path/count/categories")]
    [Produces("application/json")]
    public ActionResult<List<string>> GetNumberOfItemsForCategories()
    {
        return _storeService.GetNumberOfItemsForCategories();
    }

    [HttpPost]
    public ActionResult SetStock([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromHeader(Name="stock")] int stock)
    {
        _storeService.SetStock(category, item, stock);
        return new EmptyResult();
    }
}