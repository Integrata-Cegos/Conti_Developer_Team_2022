using Microsoft.AspNetCore.Mvc;
using Employees;
using System.Net.Mime;
namespace Employees.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeManager _EmployeeManager;
    public EmployeeController(EmployeeManager employeeManager)
    {
        this._EmployeeManager = employeeManager;
    }
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Employee> Create([FromHeader(Name = "name")]string name, [FromHeader(Name = "lastname")]string lastname, [FromHeader(Name = "firstname")]string firstname, [FromHeader(Name = "email")]string email, [FromHeader(Name = "homePage")]string homePage)
    {    {
        try
        {
            return _EmployeeManager.Create(name, lastname, firstname, email, homePage);
        }
        catch
        {
            return UnprocessableEntity();
        }

    }


    }
    [HttpPut]
    [Consumes("application/json")]
    public ActionResult Update([FromBody]Employee employee)
    {
        {
            try
            {
                _EmployeeManager.Update(employee);
                return new EmptyResult();
            }
            catch
            {
                return UnprocessableEntity();
            }

        }

    }
    [HttpDelete]
    public ActionResult Delete([FromHeader(Name = "id")]int id)
    {
        try
        {
            _EmployeeManager.Delete(id);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }

    }
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]

    public ActionResult<List<Employee>> FindAll()
    {
        try
        {
            return _EmployeeManager.FindAll();
        }
        catch
        {
            return NotFound();
        }

    }
    [HttpGet("id")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Employee> FindById([FromHeader(Name = "id")]int id)
    {
        try
        {
            return _EmployeeManager.FindById(id);
        }
        catch
        {
            return NotFound();
        }

    }
    [HttpGet("name")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Employee> FindByName([FromHeader(Name = "name")]string name)
    {
        try
        {
            return _EmployeeManager.FindByName(name);
        }
        catch
        {
            return NotFound();
        }

    }
    [HttpGet("lastname")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Employee> FindByLastname([FromHeader(Name = "lastname")]string lastname)
    {
        try
        {
            return _EmployeeManager.FindByLastname(lastname);
        }
        catch
        {
            return NotFound();
        }

    }
    [HttpGet("firstname")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Employee> FindByFirstname([FromHeader(Name = "firstname")]string firstname)
    {
        try
        {
            return _EmployeeManager.FindByFirstname(firstname);
        }
        catch
        {
            return NotFound();
        }

    }
        [HttpGet("email")]
    [Produces(MediaTypeNames.Application.Json)]

    public ActionResult<Employee> FindByEMail([FromHeader(Name = "email")]string eMail)
    {
        try
        {
            return _EmployeeManager.FindByEMail(eMail);
        }
        catch
        {
            return NotFound();
        }
    }
        [HttpGet("homePage")]
    [Produces(MediaTypeNames.Application.Json)]

    public ActionResult<Employee> FindByHomePage([FromHeader(Name = "homePage")]string homePage)
    {
        try
        {
            return _EmployeeManager.FindByHomePage(homePage);
        }
        catch
        {
            return NotFound();
        }

    }
}


