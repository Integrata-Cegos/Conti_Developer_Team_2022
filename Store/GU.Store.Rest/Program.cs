using GU.Store.API;
using GU.Store.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//In älteren Versionen: public void ConfigureServices(... services){services.AddControllers()}
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStoreService>(new StoreService());
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
