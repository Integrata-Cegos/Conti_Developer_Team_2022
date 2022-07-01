using Microsoft.AspNetCore.Mvc;
using ContiLS.IsbnGenerator.API;
using System.Net.Mime;

namespace ContiLS.Publishing.Rest.Controllers;

[ApiController]
[Route("api/isbn")]
public class IsbnWebServiceController : ControllerBase
{
    [HttpPost]
    [Produces(MediaTypeNames.Text.Plain)]
    public ActionResult<String> Next([FromServices] IIsbnService isbnService){
        return isbnService.Next().ToString();
    }

}