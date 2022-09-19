using Microsoft.AspNetCore.Mvc;

namespace Conti.AB.Content.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentController : ControllerBase
{
   IContentService _contentService;

   public ContentController (IContentService _contentService)
   {
       _contentService = contentService;
   }

   [HttpGet("byIsbn")]
   [Produces(MediaTypeNames.Application.Json)]
   public ActionResult<string> GetContent ([FromHeader(Name = "ISBN")] string isbn)
   {
       try
       {
           var content = _contentService.GetContent(isbn);
           return content;
       }
       catch (Exception)
       {
           return NotFound();
       }
   }
}
