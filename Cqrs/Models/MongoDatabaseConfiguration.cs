namespace Cqrs.Models;

public sealed class MongoDatabaseConfiguration
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionName { get; set; }
}