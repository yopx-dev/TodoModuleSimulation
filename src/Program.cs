using TodoModule.Controller;
using TodoModule.Core;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<TodoStorage>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();