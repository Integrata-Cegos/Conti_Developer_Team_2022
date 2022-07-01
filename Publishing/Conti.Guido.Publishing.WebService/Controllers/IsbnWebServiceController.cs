using Microsoft.AspNetCore.Mvc;
using Conti.Guido.IsbnGenerator.API;
using Conti.Guido.Books.API;
using System.Net.Mime;
namespace Conti.Guido.Store.Rest.Controllers;

[ApiController]
[Route("api/isbn")]
public class IsbnWebServiceController : ControllerBase
{
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public Isbn Next([FromServices] IIsbnService isbnService){
        return isbnService.Next();
    }

}

