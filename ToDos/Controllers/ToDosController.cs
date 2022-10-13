using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
namespace ToDos.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDosController : ControllerBase
{
    private readonly ToDosManagement _ToDosManagement;
    public ToDosController(ToDosManagement toDosManagement)
    {
        this._ToDosManagement = toDosManagement;
    }

    [HttpPost]
    public ActionResult<ToDo> Create([FromHeader(Name = "description")] string description)
    {
        try
        {
            return _ToDosManagement.Create(description);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
    [HttpPut("status")]
    public ActionResult UpdateStatus([FromHeader(Name = "id")] int id, [FromHeader(Name = "status")] Status status)
    {
        try
        {
            _ToDosManagement.UpdateStatus(id, status);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
    [HttpPut("priority")]
    public ActionResult UpdatePriority([FromHeader(Name = "id")] int id, [FromHeader(Name = "priority")] Priority priority)
    {
        try
        {
            _ToDosManagement.UpdatePriority(id, priority);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
    [HttpGet("open")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<ToDo>> OpenToDos()
    {
        try
        {
            return _ToDosManagement.OpenToDos();
        }
        catch
        {
            return NotFound();
        }
    }
    [HttpGet("finished")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<ToDo>> FinishedToDos()
    {
        try
        {
            return _ToDosManagement.FinishedToDos();
        }
        catch
        {
            return NotFound();
        }
    }


}
