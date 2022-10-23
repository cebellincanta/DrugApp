using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Repository;
using DrugovichApp.IOC.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrugovichApp.IOC;

public static class DependencyContainer
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterContext(services, configuration);
    }

    public static void RegisterContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDBContextConfiguration(configuration);
    }

    public static void RegisterRepository(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IGrupoRepository, GrupoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
} 