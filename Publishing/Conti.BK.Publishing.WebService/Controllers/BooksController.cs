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
    public string PostCreateBook([FromHeader]string title, [FromHeader]int pages,[FromHeader] double price,[FromHeader] Dictionary<string, Object> options)
    {
        return _booksService.CreateBook(title,pages,price,options).IsbnString;
    }
    [HttpPut("UpdateBook")]
    public void Update([FromHeader]Book book)
    {
        _booksService.UpdateBook(book);
    }
    [HttpGet("FindBookByIsbn")]
    [Produces(MediaTypeNames.Application.Json)]
    public Book GetFindBookByIsbn([FromHeader]string isbnString){
        return _booksService.FindBookByIsbn(new Isbn(isbnString));
    }
    [HttpGet("FindBooksByTitle")]
    [Produces(MediaTypeNames.Application.Json)]
    public List<Book> GetFindBooksByTitle([FromHeader]string title){
        return _booksService.FindBooksByTitle(title);
    }
    [HttpGet("FindBooksByPriceRange")]
    [Produces(MediaTypeNames.Application.Json)]
    public List<Book> GetFindBooksByPriceRange([FromHeader]double minPrice, [FromHeader]double maxPrice){
        return _booksService.FindBooksByPriceRange(minPrice,maxPrice);
    }
    [HttpDelete("DeleteBookByIsbn")]
    [Produces(MediaTypeNames.Application.Json)]
    public void DeleteDeleteBookByIsbn([FromHeader]string isbnString){
        _booksService.DeleteBookByIsbn(new Isbn(isbnString));
    }
}
