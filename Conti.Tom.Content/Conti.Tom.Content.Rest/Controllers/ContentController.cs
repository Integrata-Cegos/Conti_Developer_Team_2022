using Conti.Tom.Content.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Conti.Tom.Content.Rest.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    IContentService _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet("byISBN")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<string> GetContent([FromHeader(Name = "ISBN")] string ISBN)
    {
        try
        {
            var content = _contentService.GetContent(ISBN);
            return content;
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}
