using Employees.Models;

namespace Employees.Repositories;

public class UserRepository
{
    public static List<User> Users = new()
        {
            new() { Username = "training", EmailAddress = "Thomas.Herdegen@continental.com", Password = "training", GivenName = "API", Surname = "API", Role = "Administrator" },
            //new() { Username = "lydia_standard", EmailAddress = "lydia.standard@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Burton", Role = "Standard" },
        };
}
