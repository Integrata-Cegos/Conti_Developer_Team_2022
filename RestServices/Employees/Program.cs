using Employees;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EmployeeService employeeService = new();

static bool ValidateHomepage(string homepage)
{
    Uri uriResult;
    return Uri.TryCreate(homepage, UriKind.Absolute, out uriResult)
        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}

app.MapPost("/CreateEmployee", (Employee employee) =>
{
    if (!ValidateHomepage(employee.Homepage)) { return Results.Text("Homepage URL not valid!"); }

    employeeService.CreateEmployee(employee);

    return Results.Ok("User Created");
});

app.MapGet("GetEmplyees", () =>
{
    return employeeService.GetEmployees();
});

app.MapPut("/UpdateEmployee/{id}", (int id, Employee employee) =>
{
    if (!ValidateHomepage(employee.Homepage)) { return Results.Text("Homepage URL not valid!"); }
    try
    {
        return Results.Ok(employeeService.EditEmployee(id, employee));
    }
    catch (Exception ex)
    {
        //there have an exception to query data from the the Repository.
        return Results.Ok(new { ErrorMessage = ex.Message });
    }
});

app.MapDelete("/DeleteEmployee/{id}", (int id) =>
{
    try
    {
        return Results.Ok(employeeService.DeleteEmployee(id));
    }
    catch (Exception ex)
    {
        //there have an exception to query data from the the Repository.
        return Results.Ok(new { ErrorMessage = $"{ex.Message} {ex.InnerException?.Message}" });
    }
});


app.Run();
