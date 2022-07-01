using Microsoft.AspNetCore.Mvc;
using Conti.AB.Books.API;
using Conti.AB.IsbnGenerator.API;
using System.Net.Mime;

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

    [HttpGet("{isbn}")]
    [Produces(MediaTypeNames.Application.Json)]
    public Book FindBookByIsbn([FromRoute(Name = "isbn")] Isbn isbn)
    {
        return _booksService.FindBookByIsbn(isbn);
    }
} 

