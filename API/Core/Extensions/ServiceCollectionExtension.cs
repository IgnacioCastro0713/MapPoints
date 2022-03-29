using API.Core.Helpers;
using API.Core.Interfaces;
using API.Core.Interfaces.Services;
using API.Persistance;
using API.Persistance.DbContext;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddMySqlDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            optionsBuilder.UseMySql(
                configuration.GetConnectionString("Connection"),
                ServerVersion.Parse(configuration.GetConnectionString("MySqlServerVersion"))
            ));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
    }
}