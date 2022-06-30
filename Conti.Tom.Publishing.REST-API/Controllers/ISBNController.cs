namespace Conti.Tom.Publishing.REST_API.Controllers;
[ApiController]
[Route("[controller]")]
public class ISBNController : ControllerBase
{
    IISBNService _ISBNService;
    public ISBNController(IISBNService iSBNService)
    {   
        _ISBNService = iSBNService;
    }

    [HttpGet("next")]
    public string Next()
    {
        return _ISBNService.Next().ToString();
    }
}
