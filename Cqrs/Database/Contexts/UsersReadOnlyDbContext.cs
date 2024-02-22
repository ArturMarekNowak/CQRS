using Cqrs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cqrs.Database.Contexts;

public sealed class UsersReadOnlyDbContext : UsersBaseDbContext
{
    private readonly DatabaseConfiguration _databaseConfiguration;

    public UsersReadOnlyDbContext(IOptions<DatabaseConfiguration> databaseConfiguration)
    : base(databaseConfiguration.Value.ReadOnlyConnectionString!)
    {
        _databaseConfiguration = databaseConfiguration.Value;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_databaseConfiguration.ReadOnlyConnectionString);
    }
}