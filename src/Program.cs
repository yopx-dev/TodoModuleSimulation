using Microsoft.EntityFrameworkCore;
using TodoModule.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TodoStorage>();
builder.Services.AddControllers();

// Use your options for data base.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(""));

var app = builder.Build();

app.MapControllers();

app.Run();