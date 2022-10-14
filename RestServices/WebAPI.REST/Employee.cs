using System.ComponentModel.DataAnnotations;

namespace Employees;

[Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
public class Employee
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Homepage { get; set; }

    public Employee(string name, string firstName, string lastName, string email, string homepage)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Homepage = homepage;
    }
}
