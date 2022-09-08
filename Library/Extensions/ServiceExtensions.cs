using Contracts;
using Entities;
using Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;

namespace Library.Extensions;

public static class ServiceExtensions
{
    public static void ConfifureCors(this IServiceCollection services)
    {
        services.AddCors(options => 
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    public static void ConfigureIISIntegration(this IServiceCollection services) 
    {
        services.Configure<IISOptions>(options => 
        {
        
        });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["sqlserverconnection:connectionString"];

        services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}