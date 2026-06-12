using Microsoft.EntityFrameworkCore;
using TodoModule.Context;

namespace TodoModule.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Todo> Todos { get; set; }
}