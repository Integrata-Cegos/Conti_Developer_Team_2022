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
    public String GetStock([FromRoute(Name="ItemCategory")] string category, [FromRoute(Name="ItemId")]string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return _storeService.GetStock(category, item).ToString();
    }

    [HttpGet("header")]
    public String GetStockUsingHeaders([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromServices] IStoreService iss)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return iss.GetStock(category, item).ToString();
    }
    [HttpGet("query")]
    public String GetStockUsingQuery([FromQuery(Name="ItemCategory")] string category, [FromQuery(Name="ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }
    [HttpGet("mixed/{ItemId}")]
    public String GetStockMixed([FromHeader(Name="ItemCategory")] string category, [FromRoute(Name="ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }
    [HttpPost]
    public void SetStock([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item, [FromHeader(Name="stock")] int stock){
        Console.WriteLine($"retrieving stock for category={category} and item={item} and stock={stock}");
        _storeService.SetStock(category, item, stock);
    }

}