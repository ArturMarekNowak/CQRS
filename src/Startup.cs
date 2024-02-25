using Cqrs.Database.Contexts;
using Cqrs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Cqrs;

public sealed class Startup
{
    private IConfiguration Configuration { get; }
        
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
        
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cqrs" });
        });
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Startup).Assembly);
        });
        
        services.Configure<DatabaseConfiguration>(Configuration.GetSection("ConnectionStrings"));
        services.AddDbContext<UsersBaseDbContext>(options => 
            options.UseNpgsql(Configuration.GetValue<string>("ConnectionStrings:ReadWriteConnectionString")));
        services.AddScoped<UsersReadWriteDbContext>();
        services.AddScoped<UsersReadOnlyDbContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cqrs"));

        app.UseHttpsRedirection();
        app.UseRouting();
            
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}