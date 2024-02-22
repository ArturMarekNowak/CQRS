using Cqrs.Models;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Database.Contexts;

public class UsersBaseDbContext : DbContext
{
    public UsersBaseDbContext()
    { }
    
    public UsersBaseDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public UsersBaseDbContext(DbContextOptions<UsersBaseDbContext> dbContextOptions) : base(dbContextOptions)
    { }

    public DbSet<User> Users { get; set; }
    private readonly string _connectionString;
}