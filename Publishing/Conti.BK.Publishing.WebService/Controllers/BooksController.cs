using Microsoft.AspNetCore.Mvc;
using Conti.BK.IsbnGenerator.Impl;
using Conti.BK.IsbnGenerator.API;
using Conti.BK.Store.API;
using Conti.BK.Books.API;
using System.Net.Mime;
using System.Collections.Generic;

namespace Conti.BK.Publishing.WebService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
  
    private readonly IIsbnService _isbnService;
    private readonly IStoreService _storeService;
    private readonly IBooksService _booksService;

    public BooksController(IIsbnService isbnService, IStoreService storeService, IBooksService booksService)
    {
        _isbnService = isbnService;
        _storeService = storeService;
        _booksService = booksService;
    }

    [HttpPost("CreateBook")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<string> PostCreateBook([FromHeader]string title, [FromHeader]int pages,[FromHeader] double price,[FromHeader] Dictionary<string, Object> options)
    {
        return _booksService.CreateBook(title,pages,price,options).IsbnString;
    }
    [HttpPut("UpdateBook")]
    public ActionResult Update([FromHeader]Book book)
    {
        try
        {
            _booksService.UpdateBook(book);
        }
        catch (System.Exception)
        {
            return NotFound();
        }
        
        return Ok();
    }
    [HttpGet("FindBookByIsbn")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Book> GetFindBookByIsbn([FromHeader]string isbnString){
        try
        {
            return _booksService.FindBookByIsbn(new Isbn(isbnString));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
        
    }
    [HttpGet("FindBooksByTitle")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Book>> GetFindBooksByTitle([FromHeader]string title){
        var result= _booksService.FindBooksByTitle(title);
        if(result.Count == 0){
            return NoContent();
        }
        return result;
        
    }
    [HttpGet("FindBooksByPriceRange")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Book>> GetFindBooksByPriceRange([FromHeader]double minPrice, [FromHeader]double maxPrice){
        var result = _booksService.FindBooksByPriceRange(minPrice,maxPrice);
        if(result.Count == 0){
            return NoContent();
        }
        return result;
    }
    [HttpDelete("DeleteBookByIsbn")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult DeleteDeleteBookByIsbn([FromHeader]string isbnString){
        
        try
        {
            _booksService.DeleteBookByIsbn(new Isbn(isbnString));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
        return Ok();
    }
}
