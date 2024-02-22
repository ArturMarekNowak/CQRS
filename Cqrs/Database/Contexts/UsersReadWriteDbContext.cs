using Cqrs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cqrs.Database.Contexts;

public sealed class UsersReadWriteDbContext : UsersBaseDbContext
{
    private readonly DatabaseConfiguration _databaseConfiguration;

    public UsersReadWriteDbContext(IOptions<DatabaseConfiguration> databaseConfiguration) 
    : base(databaseConfiguration.Value.ReadWriteConnectionString!)
    {
        _databaseConfiguration = databaseConfiguration.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_databaseConfiguration.ReadWriteConnectionString);
    }
}