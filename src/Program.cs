using Cqrs.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Cqrs;

public sealed class Program
{
    public static void Main(string[] args)
    { 
        var host = CreateHostBuilder(args).Build();

        // https://stackoverflow.com/questions/36265827/entity-framework-automatic-apply-migrations
        MigrateDatabase(host);
        
        host.Run();
    }

    private static void MigrateDatabase(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<UsersReadWriteDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogCritical(ex, "An error occurred creating the DB.");
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}