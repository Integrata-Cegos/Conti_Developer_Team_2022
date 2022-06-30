using Conti.Guido.IsbnGenerator.API;
using Conti.Guido.IsbnGenerator.Impl;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var isbnGenerator = new RandomIsbnService();
isbnGenerator.Prefix = "REST-ISBN";
isbnGenerator.CountryCode = "-dk";
builder.Services.AddSingleton<IIsbnService>(isbnGenerator); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();