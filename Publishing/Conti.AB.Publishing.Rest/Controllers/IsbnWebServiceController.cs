using Microsoft.AspNetCore.Mvc;
using Conti.AB.IsbnGenerator.API;
using System.Net.Mime;

namespace Conti.AB.Publishing.Rest.Controllers;

[ApiController]
[Route("api/isbn")]

public class IsbnWebServiceController : ControllerBase
{
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public string Next([FromServices] IIsbnService isbnService)
    {
        return isbnService.Next().ToString();
    }
}

