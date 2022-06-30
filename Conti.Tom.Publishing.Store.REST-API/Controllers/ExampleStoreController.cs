namespace Conti.Tom.Publishing.Store.REST_API.Controllers;

[ApiController]
[Route("api/examplestore")]
public class ExampleStoreController : ControllerBase
{

    [HttpGet("path/{ItemCategory}/{ItemId}")]
    public String GetStock([FromRoute(Name = "ItemCategory")] string category, [FromRoute(Name = "ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }

    [HttpGet("header")]
    public String GetStockUsingHeaders([FromHeader(Name = "ItemCategory")] string category, [FromHeader(Name = "ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }
    [HttpGet("query")]
    public String GetStockUsingQuery([FromQuery(Name = "ItemCategory")] string category, [FromQuery(Name = "ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }
    [HttpGet("mixed/{ItemId}")]
    public String GetStockMixed([FromHeader(Name = "ItemCategory")] string category, [FromRoute(Name = "ItemId")] string item)
    {
        Console.WriteLine($"retrieving stock for category={category} and item={item}");
        return "Stock: 42";
    }

}
