using Microsoft.AspNetCore.Mvc;
using Javacream.Books.API;
using Javacream.IsbnGenerator.API;
using System.Net.Mime;
using System.Collections.Generic;
namespace Javacream.Store.Rest.Controllers;

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
    public Book FindBookByIsbn([FromHeader(Name = "isbn")] String isbn){
        return _booksService.FindBookByIsbn(From(isbn));
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
    private Isbn From(string isbnAsString)
    {
        string[] split1 = isbnAsString.Split(":");
        string prefix = split1[0];
        string[] split2 = split1[1].Split("-");
        int part1 = Int32.Parse(split2[0]);
        int part2 = Int32.Parse(split2[1]);
        int part3 = Int32.Parse(split2[2]);
        int part4 = Int32.Parse(split2[3]);
        string countryCode = split2[4];
        return new Isbn(prefix, countryCode, part1, part2, part3, part4);
    }
}
