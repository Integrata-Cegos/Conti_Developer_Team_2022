using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Employees;

public class SearchCriteria
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Homepage { get; set; }


    public static ValueTask<SearchCriteria?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        string name = context.Request.Query["Name"];
        string firstname = context.Request.Query["FirstName"];
        string lastname = context.Request.Query["LastName"];
        string email = context.Request.Query["Email"];
        string homepage = context.Request.Query["Homepage"];

        var result = new SearchCriteria
        {
            Name = name,
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Homepage = homepage,
        };
        return ValueTask.FromResult<SearchCriteria?>(result);
    }
}
