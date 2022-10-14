namespace Employees;

public class EmployeeService
{
    public List<Employee> DataBase { get; set; } = new();

    public Employee CreateEmployee(Employee employee)
    {
        try
        {
            DataBase.Add(employee);
            return employee;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating Employee!", ex);
        }
    }

    public List<Employee> GetEmployees()
    {
        return DataBase;
    }

    public Employee EditEmployee(int id, Employee employee)
    {
        try
        {
            DataBase.Where(x => x.Id == id).First().Name = employee.Name;
            DataBase.Where(x => x.Id == id).First().FirstName = employee.FirstName;
            DataBase.Where(x => x.Id == id).First().LastName = employee.LastName;
            DataBase.Where(x => x.Id == id).First().Email = employee.Email;
            DataBase.Where(x => x.Id == id).First().Homepage = employee.Homepage;
            return DataBase.Where(x => x.Id == id).First();
        }
        catch (InvalidOperationException ex)
        {
            throw new Exception("User unknown!", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("Error Editing Employee!", ex);
        }
    }

    public bool DeleteEmployee(int id)
    {
        try
        {
            if (DataBase.RemoveAll(x => x.Id == id) == 0)
            {
                throw new KeyNotFoundException($"Employee with id {id} not found!");
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting Employee!", ex);
        }
    }

}
