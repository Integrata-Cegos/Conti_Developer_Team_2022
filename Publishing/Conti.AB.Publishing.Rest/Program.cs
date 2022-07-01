using Conti.AB.IsbnGenerator.API;
using Conti.AB.IsbnGenerator.Impl;
using Conti.AB.Store.API;
using Conti.AB.Store.Impl;
using Conti.AB.Books.API;
using Conti.AB.Books.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var isbnGenerator = new RandomIsbnService();
isbnGenerator.Prefix = "REST-ISBN";
isbnGenerator.CountryCode = "-dk";
var storeService = new StoreService();
storeService.SetStock("books", new Isbn(4,5,6,7), 100);
storeService.SetStock("books", new Isbn(4,5,6,8), 10);
var booksService = new BooksService(isbnGenerator, storeService);

builder.Services.AddSingleton<IIsbnService>(isbnGenerator);
builder.Services.AddSingleton<IBooksService>(booksService);
builder.Services.AddSingleton<IStoreService>(storeService);

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
