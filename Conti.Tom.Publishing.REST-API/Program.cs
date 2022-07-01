using Conti.Tom.Publishing.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _ISBNService = new RandomISBNService();
_ISBNService.Prefix = "ISBN:";
_ISBNService.CountryCode = "DE";
var _StoreService = new StoreService();
_StoreService.SetStock("books", _ISBNService.Next(), 100);
var _BooksService = new BooksService(_ISBNService, _StoreService);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IISBNService>(_ISBNService);
builder.Services.AddSingleton<IBooksService>(_BooksService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
