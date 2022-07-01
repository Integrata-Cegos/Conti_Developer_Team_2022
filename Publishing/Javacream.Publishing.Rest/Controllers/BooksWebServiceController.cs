using Microsoft.AspNetCore.Mvc;
using Javacream.Books.API;
using Javacream.IsbnGenerator.API;
using System.Net.Mime;
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
    [HttpGet("{isbn}")]
    [Produces(MediaTypeNames.Application.Json)]
    public Book FindBookByIsbn([FromRoute(Name = "isbn")] Isbn isbn){
        return _booksService.FindBookByIsbn(isbn);
    }

}
