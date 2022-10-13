namespace Employees{

    public class Employee{
        public int Id {get;set;}
        public string? Name  {get;set;}
        public string? Lastname {get;set;}
        public string? Firstname {get;set;}
        public string? Email {get;set;}

        public string? HomePage  {get;set;}

        public Employee(){}
        public Employee(int id, string name, string lastname, string firstname, string email, string homePage)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.Email = email;
            this.HomePage = homePage;
        }

    }

    public class EmployeeManager
    {
        private static int counter = 0;
        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public Employee Create(string name, string lastname, string firstname, string email, string homePage)
        {
            var newEmployee = new Employee(counter++, name, lastname, firstname, email, homePage);
            employees.Add(newEmployee.Id, newEmployee);
            return newEmployee;
        }
        public void Update(Employee employee)
        {
            employees[employee.Id] = employee;
        }
        public void Delete(int id)
        {
            employees.Remove(id);
        }

        public List<Employee> FindAll()
        {
            return employees.Select(e => e.Value).ToList();
        }
        public Employee FindById(int id)
        {
            return employees[id];
        }
        public Employee FindByName(string name)
        {
            return employees.Single(e => e.Value.Name!.Equals(name)).Value;
        }
        public Employee FindByLastname(string lastname)
        {
            return employees.Single(e => e.Value.Lastname!.Equals(lastname)).Value;
        }
        public Employee FindByFirstname(string firstname)
        {
            return employees.Single(e => e.Value.Firstname!.Equals(firstname)).Value;
        }
        public Employee FindByEMail(string eMail)
        {
            return employees.Single(e => e.Value.Email!.Equals(eMail)).Value;
        }
        public Employee FindByHomePage(string homePage)
        {
            return employees.Single(e => e.Value.HomePage!.Equals(homePage)).Value;
        }
    }
}