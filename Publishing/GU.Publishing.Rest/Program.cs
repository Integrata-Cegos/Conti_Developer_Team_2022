using GU.IsbnGenerator.API;
using GU.IsbnGenerator.Impl;
using GU.Store.API;
using GU.Store.Impl;
using GU.Books.API;
using GU.Books.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var isbnService = new RandomIsbnService();
isbnService.Prefix = "REST";
isbnService.CountryCode = "dk";
var storeService = new StoreService();
storeService.SetStock("books", new Isbn(4,5,6,7), 100);
storeService.SetStock("books", new Isbn(4,5,6,8), 10);
var booksService = new BooksService(isbnService, storeService);
builder.Services.AddSingleton<IIsbnService>(isbnService); 
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
