using LeasingTestAssignment.API.Middlewares;
using LeasingTestAssignment.Application.Services.DependencyInjection;
using LeasingTestAssignment.Infrastructure.Persistence.DependencyInjection;

namespace LeasingTestAssignment.API;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseContexts(_configuration);
        services.AddRepositories();
        services.AddApplicationServices();

        services.AddControllers();

        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(builder =>
        {
            builder.MapControllers();
        });
    }
}
