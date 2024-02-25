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

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new InvalidOperationException("Attempted to modify changes with read only database context");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        throw new InvalidOperationException("Attempted to modify changes with read only database context");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        throw new InvalidOperationException("Attempted to modify changes with read only database context");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_databaseConfiguration.ReadOnlyConnectionString);
    }
}