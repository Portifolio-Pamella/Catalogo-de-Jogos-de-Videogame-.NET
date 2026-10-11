using MongoCrudApi.Data;
using MongoCrudApi.Models;
using MongoCrudApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Options Pattern
builder.Services.Configure<GameStoreDatabaseSettings>(
    builder.Configuration.GetSection("GameStoreDatabase"));

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<GameService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();