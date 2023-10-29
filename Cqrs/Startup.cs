using Cqrs.Models;
using Cqrs.Services;
using Cqrs.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace Cqrs;

public sealed class Startup
{
    public IConfiguration Configuration { get; }
        
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
        services.Configure<DatabasesConfiguration>(Configuration.GetSection("Databases"));
        services.AddScoped<IUsersService, UsersService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cqrs"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
            
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}