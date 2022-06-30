using Microsoft.AspNetCore.Mvc;
using Conti.AB.Store.API;

namespace StoreWebService.Controllers;

[ApiController]
[Route("api/store")]

public class StoreWebServiceController : ControllerBase
{
    private readonly IStoreService _storeService;

    public StoreWebServiceController (IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("{category}/{item}")]
    public string GetStock (string category, string item)
    {
        return "Stock: 42";
    }

    [HttpGet("GetStock")]
    public int GetStockWithService ([FromHeader(Name="ItemCategory")] string category, [FromHeader(Name="ItemId")] string item)
    {
        return _storeService.GetStock(category, item);
    }

    [HttpPost("SetStock/{category}/{item}/{stock}")]
    public void SetStock (string category, string item, int stock)
    {
        _storeService.SetStock(category, item, stock);
    }
}