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

    [HttpDelete("path/{ItemCategory}/{ItemId}")]
    public void DeleteItemFromStore([FromRoute(Name = "ItemCategory")] string category, [FromRoute(Name = "ItemId")] string item)
    {
        _storeService.DeleteItemFromStore(category, item);
    }

    [HttpDelete("path/{ItemCategory}")]
    public void DeleteCategory([FromRoute(Name = "ItemCategory")] string category)
    {
        _storeService.DeleteCategory(category);
    }

    [HttpGet("path/{ItemCategory}")]
    [Produces("text/plain")]
    public ActionResult<String> GetNumberOfItemsFor([FromRoute(Name = "ItemCategory")] string category)
    {
        return _storeService.GetNumberOfItemsFor(category).ToString();
    }

    [HttpGet("path/GetNumberOfItemsForCategories")]
    [Produces("application/json")]
    public ActionResult<Dictionary<string,int>> GetNumberOfItemsForCategories()
    {
        return _storeService.GetNumberOfItemsForCategories();
    }

    [HttpGet("path/GetCategories")]
    [Produces("application/json")]
    public ActionResult<List<String>> GetCategories()
    {
        return _storeService.GetCategories();
    }

    [HttpPost]
    public ActionResult SetStock([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromHeader(Name="stock")] int stock){
        _storeService.SetStock(category, item, stock);
        return new EmptyResult();
    }

}
