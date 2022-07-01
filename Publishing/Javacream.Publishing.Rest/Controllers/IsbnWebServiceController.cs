using Microsoft.AspNetCore.Mvc;
using Javacream.IsbnGenerator.API;
using System.Net.Mime;
namespace Javacream.Store.Rest.Controllers;

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
