using Microsoft.AspNetCore.Mvc;
using Conti.BK.Store.Impl;
using Conti.BK.Store.API;
using Conti.BK.IsbnGenerator.API;

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
    public string Post([FromHeader]string cat, [FromHeader]string isbn,[FromHeader] int count){
        _store.SetStock(cat,new Isbn(isbn),count);
        return new Isbn(isbn).IsbnString+" set to "+count;
    }

    [HttpGet("GetStock")]
    public int Get([FromHeader]string cat, [FromHeader]string isbn)
    {
        return _store.GetStock(cat,new Isbn(isbn));
    }
}
