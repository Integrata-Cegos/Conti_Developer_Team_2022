using Conti.BK.IsbnGenerator.Impl;
using Conti.BK.IsbnGenerator.API;
using Conti.BK.Books.API;
using Conti.BK.Store.API;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var isbn = new Conti.BK.IsbnGenerator.Impl.RandomIsbnService();
isbn.Prefix="ISBN:";
isbn.CountryCode="-de";
builder.Services.AddSingleton<IIsbnService>(isbn);
var store = new Conti.BK.Store.Impl.StoreService();
builder.Services.AddSingleton<IStoreService>(store);
builder.Services.AddSingleton<IBooksService>(new Conti.BK.Books.Impl.BooksService(isbn,store));

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
