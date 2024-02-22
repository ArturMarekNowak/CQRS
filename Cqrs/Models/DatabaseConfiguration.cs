namespace Cqrs.Models;

public sealed class DatabaseConfiguration
{
    public string? ReadWriteConnectionString { get; set; }
    public string? ReadOnlyConnectionString { get; set; }
}