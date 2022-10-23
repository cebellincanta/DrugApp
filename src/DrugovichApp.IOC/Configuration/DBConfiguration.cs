using DrugovichApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrugovichApp.IOC.Configuration;

public static class DBConfiguration
{
    public static string GetConnectString(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DrugovichAppContext");

        if(!string.IsNullOrEmpty(connectionString))
            return connectionString;
        return string.Empty;
    }


    public static void AddDBContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DrugovichAppContext>(
            options =>
            {
                var connectionString = GetConnectString(configuration);
                options.UseNpgsql(connectionString);
            }
        );
    }
}