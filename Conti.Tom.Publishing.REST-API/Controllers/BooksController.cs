using Conti.Tom.Publishing.Books.IsbnGenerator.Models;
using Conti.Tom.Publishing.Books.Warehouse.Models;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Conti.Tom.Publishing.REST_API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    IBooksService _booksService;
    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet("byISBN")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Book> GetBookByISBN([FromHeader(Name = "isbn")] string isbn)
    {
        try
        {
            var book = _booksService.FindBookByIsbn(ISBN.TryParse(isbn));
            return book;
        }
        catch (Exception)
        {
            return NotFound();
        }

    }

    [HttpDelete]
    public ActionResult<IActionResult> DeleteBookByISBN([FromHeader(Name = "isbn")] ISBN isbn)
    {
        try
        {
            _booksService.DeleteBookByIsbn(isbn);
            return Ok();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpGet("byTitle")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Book>> FindBookByTitle([FromHeader(Name = "title")] string title)
    {
        try
        {
            var books = _booksService.FindBooksByTitle(title);
            if (books.Count == 0)
            {
                return NotFound();
            }
            return books;
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("byPriceRange")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Book>> FindBookByPriceRange([FromHeader(Name = "minPrice")] double minPrice, [FromHeader(Name = "maxPrice")] double maxPrice)
    {
        try
        {
            var books = _booksService.FindBooksByPriceRange(minPrice, maxPrice);
            if (books.Count == 0)
            {
                return NotFound();
            }
            return books;
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public ActionResult<ISBN> CreateBook([FromHeader(Name = "title")] string title, [FromHeader(Name = "pages")] int pages, [FromHeader(Name = "price")] double price, [FromHeader(Name = "options")] Dictionary<string, Object> options)
    {
        try
        {
            return _booksService.CreateBook(title, pages, price, options);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public ActionResult<IActionResult> Update([FromHeader(Name = "book")] Book book)
    {
        try
        {
            _booksService.UpdateBook(book);
            return Ok();

        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

}
