using Employees.Models;

namespace Employees.Services;

public interface IUserService
{
    public User Get(UserLogin userLogin);
}
