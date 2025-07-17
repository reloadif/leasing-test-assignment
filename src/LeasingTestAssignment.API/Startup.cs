namespace LeasingTestAssignment.API;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddDatabaseMigrations(_configuration);
        //services.AddDatabaseContexts(_configuration);
        //services.AddRepositories();
        //services.AddLogicServices();

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

        //app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseEndpoints(builder =>
        {
            builder.MapControllers();
        });
    }
}
