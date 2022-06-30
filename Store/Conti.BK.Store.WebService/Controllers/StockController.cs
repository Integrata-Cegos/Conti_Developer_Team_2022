using Microsoft.AspNetCore.Mvc;
using Conti.BK.Store.Impl;
using Conti.BK.Store.API;

namespace Conti.BK.Store.WebService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private IStoreService _store;
    public StockController(IStoreService store){
_store=store;
    }
    [HttpPost("SetStock")]
    public string Post([FromHeader]string cat, [FromHeader]Isbn isbn,[FromHeader] int count){
        _store.SetStock(cat,isbn,count);
        return "set to "+count;
    }

    [HttpGet("GetStock")]
    public int Get([FromHeader]string cat, [FromHeader]Isbn isbn)
    {
        return _store.GetStock(cat,isbn);
    }
}
