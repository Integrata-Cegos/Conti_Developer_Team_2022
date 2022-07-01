using Microsoft.AspNetCore.Mvc;
using ContiLS.Books.API;
using ContiLS.IsbnGenerator.API;
using System.Net.Mime;
using System.Collections.Generic;

namespace ContiLS.Publishing.Rest.Controllers;
[ApiController]
[Route("api/book")]
public class BooksWebServiceController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksWebServiceController(IBooksService booksService)
    {
        _booksService = booksService;
    }
    [HttpGet("byIsbn")]
    [Produces(MediaTypeNames.Application.Json)]
    public Book FindBookByIsbn([FromHeader(Name = "isbn")] Isbn isbn){
        return _booksService.FindBookByIsbn(isbn);
    }

    [HttpPost]
    public Isbn CreateBook([FromHeader(Name="title")] string title, [FromHeader(Name="pages")] int pages, [FromHeader(Name="price")]double price, [FromHeader(Name="options")]Dictionary<string, Object> options){
         return _booksService.CreateBook(title, pages, price, options);
    }

    [HttpDelete]
    public void DeleteBookByIsbn([FromHeader(Name = "isbn")]Isbn isbn)
    {
        _booksService.DeleteBookByIsbn(isbn);
    }
    [HttpGet("byTitle")]
    public List<Book> FindBooksByTitle([FromHeader(Name = "title")]string title)
    {
        return _booksService.FindBooksByTitle(title);
    }

    [HttpGet("byPriceRange")]
    public List<Book> FindBooksByPriceRange([FromHeader(Name = "minPrice")] double minPrice, [FromHeader(Name = "maxPrice")] double maxPrice)
    {
        return _booksService.FindBooksByPriceRange(minPrice, maxPrice);
    }

    [HttpPut]
    public void Update([FromHeader(Name = "book")]Book book)
    {
        _booksService.UpdateBook(book);
    }

}