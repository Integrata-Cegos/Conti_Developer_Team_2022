using Microsoft.AspNetCore.Mvc;
using Conti.BK.Store.Impl;
using Conti.BK.Store.API;
//using Conti.BK.IsbnGenerator.API;

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
        //_store.SetStock(cat,new Isbn(isbn),count);
        _store.SetStock(cat,isbn,count);
        //return new Isbn(isbn).IsbnString+" set to "+count;
        return isbn+" set to "+count;
    }

    [HttpGet("GetStock")]
    public int Get([FromHeader]string cat, [FromHeader]string isbn)
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        return _store.GetStock(cat,isbn);
    }



    [HttpGet("GetNumberOfItemsInCategorys")]
    public List<KeyValuePair<string,int>> GetNumberOfItemsForCats()
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        return _store.GetNumberOfItemsForCats();
    }
    [HttpGet("GetAllCategorys")]
    public List<string> GetAllCategorys()
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        return _store.GetAllCat();
    }
    [HttpGet("GetNumberOfItemsInCategory")]
    public int GetNumberOfItemsInCategory([FromHeader]string cat)
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        return _store.GetNumberOfItemsFor(cat);
    }
    [HttpDelete("DeleteStock")]
    public void Del([FromHeader]string cat, [FromHeader]string isbn)
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        _store.DeleteItem(cat,isbn);
    }
    [HttpDelete("DeleteStockByCategory")]
    public void DelByCat([FromHeader]string cat)
    {
        //return _store.GetStock(cat,new Isbn(isbn));
        _store.DeleteCat(cat);
    }
}
