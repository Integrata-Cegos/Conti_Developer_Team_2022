using Microsoft.AspNetCore.Mvc;
using Conti.Joseph.IsbnGenerator.API;
using System.Net.Mime;
namespace Javacream.Store.Rest.Controllers;

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