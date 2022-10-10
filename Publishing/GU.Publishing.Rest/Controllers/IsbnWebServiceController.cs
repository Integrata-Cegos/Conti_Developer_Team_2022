using Microsoft.AspNetCore.Mvc;
using GU.IsbnGenerator.API;
using System.Net.Mime;
namespace GU.Store.Rest.Controllers;

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
