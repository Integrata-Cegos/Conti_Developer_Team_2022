using Microsoft.AspNetCore.Mvc;
using Conti.BK.IsbnGenerator.Impl;
using Conti.BK.IsbnGenerator.API;

namespace Conti.BK.Publishing.WebService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IsbnGeneratorController : ControllerBase
{
  
    private readonly IIsbnService _isbnService;

    public IsbnGeneratorController(IIsbnService isbnService)
    {
        _isbnService = isbnService;
    }

    [HttpPost("GetNextIsbn")]
    public string Post()
    {
        return _isbnService.Next().ToString();
    }
}
