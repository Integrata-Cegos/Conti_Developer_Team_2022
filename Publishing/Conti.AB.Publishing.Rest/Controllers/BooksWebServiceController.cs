using Microsoft.AspNetCore.Mvc;
using Conti.AB.Books.API;
using Conti.AB.IsbnGenerator.API;
using System.Net.Mime;
using System.Collections.Generic;

namespace Conti.AB.Publishing.Rest.Controllers;

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
    public ActionResult<Book> FindBookByIsbn([FromRoute(Name = "isbn")] string isbn)
    {
        try{
            return _booksService.FindBookByIsbn(From(isbn));
        }
        catch{
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<Isbn> CreateBook([FromHeader(Name="title")] string title, [FromHeader(Name="pages")] int pages, [FromHeader(Name="price")] double price, [FromHeader(Name="options")] Dictionary<string, Object> options)
    {
        return _booksService.CreateBook(title, pages, price, options);
    }

    [HttpDelete]
    public ActionResult DeleteBookByIsbn ([FromHeader(Name = "prefix")]string prefix,[FromHeader(Name = "countryCode")]string countryCode, [FromHeader(Name = "part1")]int part1, [FromHeader(Name = "part2")]int part2,[FromHeader(Name = "part3")]int part3,[FromHeader(Name = "part4")]int part4)
    {
        _booksService.DeleteBookByIsbn(new Isbn(prefix, countryCode, part1, part2, part3, part4));
        return new EmptyResult();
    }

    [HttpGet("byTitle")]
    public ActionResult<List<Book>> FindBooksByTitle ([FromHeader(Name="title")] string title)
    {
        var books = _booksService.FindBooksByTitle(title);
        if (books.Count == 0)
        {
            return NotFound();
        }
        else {
            return books;
        }
    }

    [HttpGet("byPriceRange")]
    public ActionResult<List<Book>> FindBooksByPriceRange ([FromHeader(Name="minPrice")] double minPrice, [FromHeader(Name="maxPrice")] double maxPrice)
    {
        var books = _booksService.FindBooksByPriceRange(minPrice, maxPrice);
        if (books.Count == 0)
        {
            return NotFound();
        }
        else {
            return books;
        }
    }

    [HttpPut]
    public ActionResult UpdatePrice([FromHeader(Name = "prefix")]string prefix,[FromHeader(Name = "countryCode")]string countryCode, [FromHeader(Name = "part1")]int part1, [FromHeader(Name = "part2")]int part2,[FromHeader(Name = "part3")]int part3,[FromHeader(Name = "part4")]int part4, [FromHeader(Name="price")] double newPrice)
    {
        var book = _booksService.FindBookByIsbn(new Isbn(prefix, countryCode, part1, part2, part3, part4));
        book.Price = newPrice;
        _booksService.UpdateBook(book);
        return new EmptyResult();
    }
    
    private Isbn From(string isbnAsString)
    {
        string[] split1= isbnAsString.Split(":");
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

